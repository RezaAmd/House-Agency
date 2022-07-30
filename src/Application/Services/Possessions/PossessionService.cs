using Application.Models;
using Application.Repositories.Possessions;

namespace Application.Services.Possessions;

public class PossessionService : IPossessionService
{
    #region Dependency Injection
    private readonly IPossessionRepository _possessionRepository;

    public PossessionService(IPossessionRepository possessionRepository)
    {
        _possessionRepository = possessionRepository;
    }
    #endregion

    public async Task<Result> CreateAsync(Possession possession, CancellationToken stoppingToken = default)
    {
        var isSaved = await _possessionRepository.AddAsync(possession, true, stoppingToken);
        if (isSaved)
            return Result.Success;
        return Result.Failed();
    }
}