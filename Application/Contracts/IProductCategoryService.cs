using Application.Dtos;

namespace Application.Contracts
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategoryViewDto>> GetAll();
        Task<ProductCategoryViewDto> GetById(int id, InputSearchDto inputSearch);
        Task<ProductCategoryViewDto> Create(ProductCategoryDto productCategoryCreate);
        Task<ProductCategoryViewDto> Update(int id, ProductCategoryDto productCategoryUpdate);
        Task<bool> Delete(int id);
    }
}