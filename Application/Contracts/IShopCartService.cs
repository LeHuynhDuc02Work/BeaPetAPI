using Application.Dtos;

namespace Application.Contracts
{
    public interface IShopCartService
    {
        Task<List<ShopCartViewDto>> GetAllByUserId(string id);
        Task<ShopCartViewDto> GetById(int id);
        Task<ShopCartViewDto> Create(ShopCartDto shopCartCreate);
        Task<ShopCartViewDto> Update(int id, ShopCartUpdateDto shopCartUpdate);
        Task<ShopCartViewDto> UpdateQuantity(int id, ShopCartUpdateDto shopCartUpdate);
        Task<bool> Delete(int id);
        Task<bool> DeleteByProductId(int id);

    }
}