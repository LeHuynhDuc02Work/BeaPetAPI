using Application.Dtos;

namespace Application.Contracts
{
    public interface IBrandService
    {
        Task<List<BrandViewDto>> GetAll(InputSearchDto inputSearch);
        Task<BrandViewDto> GetById(int id);
        Task<BrandViewDto> Create(BrandDto brandCreate);
        Task<BrandViewDto> Update(int id, BrandDto brandUpdate);
        Task<bool> Delete(int id);
    }
}