using Application.Dtos;

namespace Application.Contracts
{
    public interface IMenuService
    {
        Task<List<MenuViewDto>> GetAll(InputSearchDto inputSearch);
        Task<MenuViewDto> GetById(int id);
        Task<MenuViewDto> Create(MenuDto menuCreate);
        Task<MenuViewDto> Update(int id, MenuDto menuUpdate);
        Task<bool> Delete(int id);
    }
}