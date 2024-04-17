using Application.Dtos;

namespace Application.Contracts
{
    public interface IShopCartService
    {
        Task<List<ShopCartViewDto>> GetAll();
        Task<ShopCartViewDto> GetById(int id, InputSearchDto inputSearch);
        Task<ShopCartViewDto> Create(ShopCartDto shopCartCreate);
        Task<ShopCartViewDto> Update(int id, ShopCartDto shopCartUpdate);
        Task<bool> Delete(int id);
    }
}