using Core;
using DataAccess.Repository.Common;

namespace DataAccess.Repository.Contracts
{
    public interface ISliderRepository : IBaseRepository<Slider>
    {
        Task<Slider> GetSliderById(int Id);

        Task<bool> Exists(int Id);
    }
}