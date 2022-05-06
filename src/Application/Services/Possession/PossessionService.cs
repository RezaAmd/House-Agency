using Application.Dao;
using Application.Models;
using Domain.Entities;

namespace Application.Services
{
    public class PossessionService : IPossessionService
    {
        #region Dependency Injection
        private readonly IBaseDao<Possession, string> possessionDao;

        public PossessionService(IBaseDao<Possession, string> _possessionDao)
        {
            possessionDao = _possessionDao;
        }
        #endregion

        public async Task<Result> CreateAsync(Possession possession)
        {
            return await possessionDao.CreateAsync(possession);
        }
    }
}