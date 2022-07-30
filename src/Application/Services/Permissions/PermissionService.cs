using Application.Repositories.Possessions;

namespace Application.Services.Permissions;

public class PermissionService : IPermissionService
{
    #region Dependency Injection
    private readonly IPossessionRepository _possessionRepository;

    public PermissionService(IPossessionRepository possessionRepository)
    {
        _possessionRepository = possessionRepository;
    }
    #endregion

    public async Task CreateAsync(Possession possession, CancellationToken stoppingToken = default)
    {
        await _possessionRepository.AddAsync(possession, true, stoppingToken);
    }
}