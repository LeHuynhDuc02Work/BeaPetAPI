using Application.Contracts;
using Application.Dtos;
using Application.Helpers;
using AutoMapper;
using Core;
using DataAccess;

namespace Application.Services
{
    public class MenuService : IMenuService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MenuService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<MenuViewDto>> GetAll(InputSearchDto inputSearch)
        {
            var menus = _unitOfWork.MenuRepository.GetAll().OrderByDescending(x => x.Id);

            var pagination = new PaginationHelper<Menu>();
            var menusPagination = pagination.Paginate(menus, inputSearch.page, inputSearch.pageSize);
            var menusMap = _mapper.Map<List<MenuViewDto>>(menusPagination);
            return menusMap;
        }

        public async Task<MenuViewDto> GetById(int id)
        {
            var menu = await _unitOfWork.MenuRepository.GetMenuById(id);
            if (menu == null)
                throw new ApplicationException("NotFound");
            var menuMap = _mapper.Map<MenuViewDto>(menu);
            return menuMap;
        }

        public async Task<MenuViewDto> Create(MenuDto menuCreate)
        {
            if (menuCreate == null)
                throw new ApplicationException("NoContent");

            var _menu = _mapper.Map<Menu>(menuCreate);
            await _unitOfWork.MenuRepository.Create(_menu);
            await _unitOfWork.MenuRepository.SaveChange();

            return _mapper.Map<MenuViewDto>(_menu);
        }

        public async Task<bool> Delete(int id)
        {
            if (!await _unitOfWork.MenuRepository.Exists(id))
                throw new ApplicationException("NotFound");

            var _menu = await _unitOfWork.MenuRepository.GetMenuById(id);
            _unitOfWork.MenuRepository.Delete(_menu);

            return await _unitOfWork.MenuRepository.SaveChange();
        }

        public async Task<MenuViewDto> Update(int id, MenuDto menuUpdate)
        {
            if (!await _unitOfWork.MenuRepository.Exists(id) || menuUpdate == null)
                throw new ApplicationException("NoContent or NotFound");

            var _menu = await _unitOfWork.MenuRepository.GetMenuById(id);
            _menu.Name = menuUpdate.Name;
            _menu.Description = menuUpdate.Description;
            _menu.Position = menuUpdate.Position;
            _unitOfWork.MenuRepository.Update(_menu);
            await _unitOfWork.MenuRepository.SaveChange();

            return _mapper.Map<MenuViewDto>(_menu);
        }
    }
}