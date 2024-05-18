using Core;
using DataAccess.Repository.Common;

namespace DataAccess.Repository.Contracts
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        Task<Review> GetReviewById(int Id);

        Task<bool> Exists(int Id);
    }
}