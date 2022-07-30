namespace Application.Services.Permissions;

public interface IPermissionService
{
    Task CreateAsync(Possession possession, CancellationToken stoppingToken = default);
}