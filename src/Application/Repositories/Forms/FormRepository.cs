using Application.Interfaces.Context;

namespace Application.Repositories.Forms;

public class FormRepository : BaseRepository<Form>, IFormRepositoy
{
    #region Dependency Injection
    private readonly IDbContext _context;

    public FormRepository(IDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion


}
