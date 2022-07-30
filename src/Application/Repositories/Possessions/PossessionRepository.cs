using Application.Interfaces.Context;

namespace Application.Repositories.Possessions;

public class PossessionRepository : BaseRepository<Possession>, IPossessionRepository
{
    #region DI
    private readonly IDbContext _context;

    public PossessionRepository(IDbContext context)
        : base(context)
    {
        _context = context;
    }
    #endregion

}