using Application.Dtos;

namespace Application.Contracts
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategoryViewDto>> GetAll(InputSearchDto inputSearch);
        Task<List<ProductViewDto>> GetProductByCateId(int id, InputSearchDto inputSearch);
        Task<ProductCategoryViewDto> GetById(int id);
        Task<ProductCategoryViewDto> Create(ProductCategoryDto productCategoryCreate);
        Task<ProductCategoryViewDto> Update(int id, ProductCategoryDto productCategoryUpdate);
        Task<bool> Delete(int id);
    }
}