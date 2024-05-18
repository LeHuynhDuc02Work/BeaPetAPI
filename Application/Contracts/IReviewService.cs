using Application.Dtos;

namespace Application.Contracts
{
    public interface IReviewService
    {
        Task<List<ReviewViewDto>> GetAllByProductId(int id);

        Task<List<ReviewViewDto>> GetAll();

        Task<ReviewViewDto> GetByProductId(int id);

        Task<ReviewViewDto> Create(ReviewDto reviewCreate);

        Task<ReviewViewDto> Update(ReviewDto reviewUpdate);

        Task<bool> Delete(int id);
    }
}