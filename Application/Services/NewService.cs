using Application.Contracts;
using Application.Dtos;
using Application.Helpers;
using AutoMapper;
using Core;

namespace Application.Services
{
    public class NewService : INewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<NewViewDto>> GetAll(InputSearchDto inputSearch)
        {
            var news = _unitOfWork.NewRepository.GetAll()
                .Where(x => x.Title.Contains(inputSearch.search.Trim()))
                .OrderByDescending(x => x.Id);

            var pagination = new PaginationHelper<New>();
            var newsPagination = pagination.Paginate(news, inputSearch.page, inputSearch.pageSize);
            var newsMap = _mapper.Map<List<NewViewDto>>(newsPagination);
            return newsMap;
        }

        public async Task<NewViewDto> GetById(int id)
        {
            var _new = await _unitOfWork.NewRepository.GetNewById(id);
            if (_new == null)
                throw new ApplicationException("NotFound");
            var newMap = _mapper.Map<NewViewDto>(_new);
            return newMap;
        }

        public async Task<NewViewDto> Create(NewDto newCreate)
        {
            if (newCreate == null)
                throw new ApplicationException("NoContent");

            var _new = _mapper.Map<New>(newCreate);
            await _unitOfWork.NewRepository.Create(_new);
            await _unitOfWork.NewRepository.SaveChange();

            return _mapper.Map<NewViewDto>(_new);
        }

        public async Task<bool> Delete(int id)
        {
            if (!await _unitOfWork.NewRepository.Exists(id))
                throw new ApplicationException("NotFound");

            var _new = await _unitOfWork.NewRepository.GetNewById(id);
            _unitOfWork.NewRepository.Delete(_new);

            return await _unitOfWork.NewRepository.SaveChange();
        }

        public async Task<NewViewDto> Update(int id, NewDto newUpdate)
        {
            if (!await _unitOfWork.NewRepository.Exists(id) || newUpdate == null)
                throw new ApplicationException("NoContent or NotFound");

            var _new = await _unitOfWork.NewRepository.GetNewById(id);
            _new.Title = newUpdate.Title;
            _new.Description = newUpdate.Description;
            _new.Detail = newUpdate.Detail;
            _new.Image = newUpdate.Image;
            _unitOfWork.NewRepository.Update(_new);
            await _unitOfWork.NewRepository.SaveChange();

            return _mapper.Map<NewViewDto>(_new);
        }
    }
}