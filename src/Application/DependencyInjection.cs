using Application.Models;
using Application.Repositories.Possessions;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLogicServices(this IServiceCollection services)
        {
            // Service Life Time
            services.AddScoped<ErrorDescriber>()
                .AddHttpContextAccessor()
                .AddTransient<IMapper, Mapper>();

            #region Repositories Services
            services
                .AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>))
                .AddScoped<IControlRepository, ControlRepository>()
                .AddScoped<IFormRepositoy, FormRepository>()
                .AddScoped<IPermissionRepository, PermissionRepository>()
                .AddScoped<IPossessionRepository, PossessionRepository>()
                .AddScoped<IRegionRepository, RegionRepository>()
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                ;

            #endregion

            #region Business Services
            services
                .AddScoped<IAttachmentService, AttachmentService>()
                .AddScoped<IFormService, FormService>()
                .AddScoped<ISignInService, SignInService>()
                .AddScoped<IPermissionService, PermissionService>()
                .AddScoped<IPossessionService, PossessionService>()
                .AddScoped<IRegionService, RegionService>()
                ;
            #endregion

            return services;
        }
    }
}