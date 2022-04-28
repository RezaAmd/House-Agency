using Application.Interfaces.Context;
using Domain.Entities;

namespace Application.Dao
{
    public class PossessionDao : BaseDao<Possession, string>
    {
        #region Dependency Injection
        private readonly IDbContext context;

        public PossessionDao(IDbContext _context) : base(_context)
        {
            context = _context;
        }
        #endregion


    }
}