﻿using Application.Extensions;
using Application.Interfaces.Context;
using Application.Models;
using Domain.Entities.Identity;
using Domain.Enums;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.Users;

public class UserRepository : IUserRepository
{
    #region Constructor
    private readonly string passwordEncryptionSalt = "950922";
    private readonly IDbContext _context;

    public UserRepository(IDbContext context)
    {
        _context = context;
    }
    #endregion

    public async Task<User?> FindByIdAsync(string id, bool withRoles = false, bool withPermissions = false,
        CancellationToken cancellationToken = new())
    {
        var user = _context.Users.Where(u => u.Id == id).AsQueryable();

        if (withRoles)
            user = user.Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role);

        if (withPermissions)
            user = user.Include(u => u.Permissions)
                .ThenInclude(up => up.Permission);

        return await user.FirstOrDefaultAsync(cancellationToken);
    }

    /// <summary>
    /// Create a new user.
    /// </summary>
    /// <param name="user">New user object model.</param>
    public async Task<Result> CreateAsync(User user, string password, CancellationToken cancellationToken = new CancellationToken())
    {
        if (user != null)
        {
            if (password != null)
                user.PasswordHash = password.Encrypt(passwordEncryptionSalt);
            await _context.Users.AddAsync(user);
            if (Convert.ToBoolean(await _context.SaveChangesAsync(cancellationToken)))
                return Result.Success;
        }
        return Result.Failed();
    }

    /// <summary>
    /// Update an specific user.
    /// </summary>
    /// <param name="user">Modified user you want to update.</param>
    public async Task<Result> UpdateAsync(User user, CancellationToken cancellationToken = new CancellationToken())
    {
        _context.Users.Update(user);
        if (Convert.ToBoolean(await _context.SaveChangesAsync(cancellationToken)))
            return Result.Success;
        return Result.Failed();
    }

    /// <summary>
    /// Delete a specific user.
    /// </summary>
    /// <param name="user">User model object.</param>
    public async Task<Result> DeleteAsync(User user, CancellationToken cancellationToken = new CancellationToken())
    {
        _context.Users.Remove(user);
        if (Convert.ToBoolean(await _context.SaveChangesAsync(cancellationToken)))
            return Result.Success;
        return Result.Failed();
    }

    /// <summary>
    /// Get All Users List as Paginated List.
    /// </summary>
    /// <param name="keyword">Search to username, name, surname, fathersName and identityLetter.</param>
    /// <param name="gender">Fillter as gender.</param>
    /// <param name="tracking">For range changes.</param>
    /// <returns>List of all users</returns>
    public async Task<PaginatedList<TDestination>> GetAllAsync<TDestination>(TypeAdapterConfig? config = null, int page = 1, int pageSize = 20,
        bool withRoles = false, string? keyword = null, bool tracking = false, CancellationToken cancellationToken = new CancellationToken())
    {
        var init = _context.Users.OrderBy(u => u.CreatedDateTime).AsQueryable();

        if (!tracking)
            init = init.AsNoTracking();
        // search
        if (!string.IsNullOrEmpty(keyword))
            init = init.Where(u => u.Username.Contains(keyword) || u.Name.Contains(keyword)
             || u.Surname.Contains(keyword) || u.Email.Contains(keyword));

        // include roles
        if (withRoles)
            init = init.Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role);

        return await init
            .ProjectToType<TDestination>(config)
            .PaginatedListAsync(page, pageSize, cancellationToken);

    }

    /// <summary>
    /// Find user by identity (Username or Phone number or Email)
    /// </summary>
    /// <param name="identity">identity for find</param>
    public async Task<User> FindByIdentityAsync(string identity, bool asNoTracking = false, bool withRoles = false,
        bool withPermissions = false,
        TypeAdapterConfig? config = null)
    {
        identity = identity.ToLower();
        var init = _context.Users.Where(u => u.Username == identity
        || u.PhoneNumber == identity
        || u.Email == identity
        || u.Id == identity);
        #region include's
        if (asNoTracking)
            init = init.AsNoTracking();
        if (withRoles)
            init = init.Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role);
        if (withPermissions)
            init = init.Include(u => u.Permissions)
                .ThenInclude(up => up.Permission);
        #endregion
        return await init.FirstOrDefaultAsync();
    }

    /// <summary>
    /// Check user password is correct or not.
    /// </summary>
    /// <param name="user">User model object with password.</param>
    /// <param name="password">The password you want to check.</param>
    /// <returns>true/false</returns>
    public bool CheckPassword(User user, string password)
    {
        string encryptedPassword = password.Encrypt(passwordEncryptionSalt);
        if (user.PasswordHash == encryptedPassword)
            return true;
        return false;
    }

    #region Otp and verify
    public string GenerateOtp(string phoneNumber, HttpContext httpContext)
    {
        string code = RandomGenerator.GenerateNumber();
        httpContext.Session.SetString("SigninOtp", (code + "." + phoneNumber).Encrypt());
        return code;
    }
    public (Result Result, string PhoneNumber) VerifyOtp(string code, HttpContext httpContext)
    {
        string otpSession = httpContext.Session.GetString("SigninOtp");
        if (otpSession != null)
        {
            var otpObject = otpSession.Decrypt().Split(".");
            if (otpObject[0] == code)
            {
                httpContext.Session.Remove("SigninOtp");
                return (Result.Success, otpObject[1]);
            }
        }
        return (Result.Failed(), null);
    }

    #endregion


    #region Permission
    public async Task<Result> AddToPermissionAsync(User user, Permission permission,
        RelatedPermissionType type = RelatedPermissionType.General)
    {
        user.Permissions.Add(new(user.Id, permission.Id, type));
        return await UpdateAsync(user);
    }
    #endregion
}