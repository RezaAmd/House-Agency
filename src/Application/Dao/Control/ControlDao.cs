using Application.Interfaces.Context;
using Domain.Entities;

namespace Application.Dao
{
    public class ControlDao : BaseDao<Control, string>, IControlDao
    {
        #region Dependency Injection
        private readonly IDbContext context;

        public ControlDao(IDbContext _context) : base(_context)
        {
            context = _context;
        }
        #endregion


    }
}
