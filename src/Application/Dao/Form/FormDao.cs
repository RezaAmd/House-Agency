using Application.Interfaces.Context;
using Domain.Entities;

namespace Application.Dao
{
    public class FormDao : BaseDao<Form, long>
    {
        #region Dependency Injection
        private readonly IDbContext context;

        public FormDao(IDbContext _context) : base(_context)
        {
            context = _context;
        }
        #endregion


    }
}
