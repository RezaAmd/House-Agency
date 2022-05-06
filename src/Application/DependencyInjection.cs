using Application.Dao;
using Application.Interfaces.Identity;
using Application.Models;
using Application.Services;
using Application.Services.Identity;
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

            #region DAO Services
            services.AddScoped(typeof(IBaseDao<,>), typeof(BaseDao<,>))
                .AddScoped<IUserService, UserService>()
                .AddScoped<IRoleService, RoleDao>()
                .AddScoped<IPermissionService, PermissionDao>()
                .AddScoped<IRegionDao, RegionDao>()
                .AddScoped<IFormDao, FormDao>()
                .AddScoped<IControlDao, ControlDao>()
                ;

            #endregion

            #region Business Services
            services.AddScoped<ISignInService, SignInService>()
                .AddScoped<IFormService, FormService>()
                .AddScoped<IPossessionService, PossessionService>()
                ;
            #endregion

            return services;
        }
    }
}