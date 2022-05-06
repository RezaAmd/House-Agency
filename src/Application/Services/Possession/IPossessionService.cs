using Application.Models;
using Domain.Entities;

namespace Application.Services
{
    public interface IPossessionService
    {
        Task<Result> CreateAsync(Possession possession);
    }
}