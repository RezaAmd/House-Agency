using Application.Interfaces.Context;

namespace Application.Repositories.Controls;

public class ControlRepository : BaseRepository<Control>, IControlRepository
{
    #region Dependency Injection
    private readonly IDbContext _context;

    public ControlRepository(IDbContext context)
        : base(context)
    {
        _context = context;
    }
    #endregion

}
