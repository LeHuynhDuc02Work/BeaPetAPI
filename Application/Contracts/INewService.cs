using Application.Dtos;

namespace Application.Contracts
{
    public interface INewService
    {
        Task<List<NewViewDto>> GetAll(InputSearchDto inputSearch);
        Task<NewViewDto> GetById(int id);
        Task<NewViewDto> Create(NewDto newCreate);
        Task<NewViewDto> Update(int id, NewDto newUpdate);
        Task<bool> Delete(int id);
    }
}