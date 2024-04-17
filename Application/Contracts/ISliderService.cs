using Application.Dtos;

namespace Application.Contracts
{
    public interface ISliderService
    {
        Task<List<SliderViewDto>> GetAll();
        Task<SliderViewDto> GetById(int id, InputSearchDto inputSearch);
        Task<SliderViewDto> Create(SliderDto sliderCreate);
        Task<SliderViewDto> Update(int id, SliderDto sliderUpdate);
        Task<bool> Delete(int id);
    }
}