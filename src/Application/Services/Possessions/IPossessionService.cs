using Application.Models;

namespace Application.Services.Possessions;

public interface IPossessionService
{
    Task<Result> CreateAsync(Possession possession, CancellationToken stoppingToken = default);
}