using Application.Contracts;
using Application.Dtos;
using Application.Helpers;
using AutoMapper;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BrandService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<BrandViewDto>> GetAll(InputSearchDto inputSearch)
        {
            var brands = _unitOfWork.BrandRepository.GetAll()
                            .Where(x => x.Name.Contains(inputSearch.search.Trim()))
                            .OrderByDescending(x => x.Id);
                
            var pagination = new PaginationHelper<Brand>();
            var brandsPagination = pagination.Paginate(brands, inputSearch.page, inputSearch.pageSize);
            var brandsMap = _mapper.Map<List<BrandViewDto>>(brandsPagination);
            return brandsMap;
        }

        public async Task<List<ProductViewDto>> GetProductsByBrandId(int id, InputSearchDto inputSearch)
        {
            var products = _unitOfWork.ProductRepository.GetAll().Where(x => x.BrandId == id).OrderByDescending(x => x.Id);
            if (inputSearch.sort == "DESC")
            {
                products = products.OrderByDescending(x => x.SalePrice);
            }
            if (inputSearch.sort == "ASC")
            {
                products = products.OrderBy(x => x.SalePrice);
            }
            var pagination = new PaginationHelper<Product>();
            var productsPagination = pagination.Paginate(products, inputSearch.page, inputSearch.pageSize);
            var productsMap = _mapper.Map<List<ProductViewDto>>(productsPagination);
            return productsMap;
        }

        public async Task<BrandViewDto> GetById(int id)
        {
            var brand = await _unitOfWork.BrandRepository.GetBrandById(id);
            if (brand == null)
                throw new ApplicationException("NotFound");
            var brandMap = _mapper.Map<BrandViewDto>(brand);
            return brandMap;
        }

        public async Task<BrandViewDto> Create(BrandDto brandCreate)
        {
            if (brandCreate == null)
                throw new ApplicationException("NoContent");

            var _brand = _mapper.Map<Brand>(brandCreate);
            await _unitOfWork.BrandRepository.Create(_brand);
            await _unitOfWork.BrandRepository.SaveChange();

            return _mapper.Map<BrandViewDto>(_brand);
        }

        public async Task<bool> Delete(int id)
        {
            if (!await _unitOfWork.BrandRepository.Exists(id))
                throw new ApplicationException("NotFound");

            var _brand = await _unitOfWork.BrandRepository.GetBrandById(id);
            _unitOfWork.BrandRepository.Delete(_brand);

            return await _unitOfWork.BrandRepository.SaveChange();
        }

        public async Task<BrandViewDto> Update(int id, BrandDto brandUpdate)
        {
            if (!await _unitOfWork.BrandRepository.Exists(id) || brandUpdate == null)
                throw new ApplicationException("NoContent or NotFound");

            var _brand = await _unitOfWork.BrandRepository.GetBrandById(id);
            _brand.Name = brandUpdate.Name;
            _brand.Description = brandUpdate.Description;
            _brand.Image = brandUpdate.Image;
            _unitOfWork.BrandRepository.Update(_brand);
            await _unitOfWork.BrandRepository.SaveChange();

            return _mapper.Map<BrandViewDto>(_brand);
        }
    }
}