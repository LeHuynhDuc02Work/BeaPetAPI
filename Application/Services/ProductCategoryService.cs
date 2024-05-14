using Application.Contracts;
using Application.Dtos;
using Application.Helpers;
using AutoMapper;
using Core;

namespace Application.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductCategoryViewDto>> GetAll(InputSearchDto inputSearch)
        {
            var categories = _unitOfWork.ProductCategoryRepository.GetAll().Where(x=>x.Name.Contains(inputSearch.search.Trim()));

            var pagination = new PaginationHelper<ProductCategory>();
            var categoriesPagination = pagination.Paginate(categories, inputSearch.page, inputSearch.pageSize);
            var categoriesMap = _mapper.Map<List<ProductCategoryViewDto>>(categoriesPagination);
            return categoriesMap;
        }

        public async Task<ProductCategoryViewDto> GetById(int id)
        {
            var category = await _unitOfWork.ProductCategoryRepository.GetProductCategoryById(id);
            if (category == null)
                throw new ApplicationException("NotFound");
            var categoryMap = _mapper.Map<ProductCategoryViewDto>(category);
            return categoryMap;
        }

        public async Task<List<ProductViewDto>> GetProductByCateId(int id, InputSearchDto inputSearch)
        {
            var products = _unitOfWork.ProductRepository.GetAll().Where(x => x.ProductCategoryId == id).OrderByDescending(x => x.Id);
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

        public async Task<ProductCategoryViewDto> Create(ProductCategoryDto productCategoryCreate)
        {
            var category = _unitOfWork.ProductCategoryRepository.GetAll()
                            .FirstOrDefault(x => x.Name.Trim() == productCategoryCreate.Name.Trim());

            if (category != null)
            {
                return new ProductCategoryViewDto()
                {
                    Status = "Tên danh mục đã có vui lòng nhập tên khác!"
                };
            }    

            if (productCategoryCreate == null)
                throw new ApplicationException("NoContent");

            var _category = _mapper.Map<ProductCategory>(productCategoryCreate);

            await _unitOfWork.ProductCategoryRepository.Create(_category);
            await _unitOfWork.ProductCategoryRepository.SaveChange();

            var mapCategory = _mapper.Map<ProductCategoryViewDto>(_category);
            mapCategory.Status = "Đã thêm danh mục thành công!";
            return mapCategory;
        }

        public async Task<bool> Delete(int id)
        {
            if (!await _unitOfWork.ProductCategoryRepository.Exists(id))
                throw new ApplicationException("NotFound");

            var _category = await _unitOfWork.ProductCategoryRepository.GetProductCategoryById(id);
            _unitOfWork.ProductCategoryRepository.Delete(_category);

            return await _unitOfWork.ProductCategoryRepository.SaveChange();
        }

        public async Task<ProductCategoryViewDto> Update(int id, ProductCategoryDto productCategoryUpdate)
        {
            if (!await _unitOfWork.ProductCategoryRepository.Exists(id) || productCategoryUpdate == null)
                throw new ApplicationException("NoContent or NotFound");

            var category = _unitOfWork.ProductCategoryRepository.GetAll()
                            .FirstOrDefault(x => x.Name.Trim() == productCategoryUpdate.Name.Trim());
            var _category = await _unitOfWork.ProductCategoryRepository.GetProductCategoryById(id);

            if (category != null && category.Name.Trim() != _category.Name.Trim())
            {
                return new ProductCategoryViewDto()
                {
                    Status = "Tên danh mục đã có vui lòng nhập tên khác!"
                };
            }

            
            _category.Name = productCategoryUpdate.Name;
            _category.Description = productCategoryUpdate.Description;
            //_category.Icon = productCategoryUpdate.Icon;
            _unitOfWork.ProductCategoryRepository.Update(_category);
            await _unitOfWork.ProductCategoryRepository.SaveChange();

            return _mapper.Map<ProductCategoryViewDto>(_category);
        }

    }
}