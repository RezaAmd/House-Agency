using Application.Interfaces.Context;

namespace Application.Dao
{
    public class RegionDao : IRegionDao
    {
        #region Initialize
        private readonly IDbContext context;
        public RegionDao(IDbContext _context)
        {
            context = _context;
        }
        #endregion

    }
}