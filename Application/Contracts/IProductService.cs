using Application.Dtos;

namespace Application.Contracts
{
    public interface IProductService
    {
        Task<List<ProductViewDto>> GetAll(InputSearchDto inputSearch);
        Task<ProductViewDto> GetById(int id);
        Task<ProductViewDto> Create(ProductDto productCreate);
        Task<ProductViewDto> Update(int id, ProductDto productUpdate);
        Task<bool> Delete(int id);
    }
}