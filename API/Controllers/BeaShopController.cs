using Application;
using Application.Contracts;
using Application.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeaShopController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IMenuService _menuService;
        private readonly IProductService _productService;

        public BeaShopController(
            IBrandService brandService,
            IMenuService menuService,
            IProductService productService
            )
        {
            _brandService = brandService;
            _menuService = menuService;
            _productService = productService;
        }

        //Brand API
        [HttpGet("brands")]
        public async Task<IActionResult> GetAllBrand([FromQuery]InputSearchDto inputSearch)
        {
            return Ok(await _brandService.GetAll(inputSearch));
        }

        [HttpGet("brand/{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            return Ok(await _brandService.GetById(id));
        }

        [HttpPost("brand/create")]
        public async Task<IActionResult> CreateBrand([FromForm] BrandDto brandCreate)
        {
            return Ok(await _brandService.Create(brandCreate));
        }

        [HttpPut("brand/update/{id}")]
        public async Task<IActionResult> UpdateBrand(int id, [FromForm] BrandDto brandUpdate)
        {
            return Ok(await _brandService.Update(id, brandUpdate));
        }

        [HttpDelete("brand/delete/{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            return Ok(await _brandService.Delete(id));
        }
        //Menu API
        [HttpGet("menus")]
        public async Task<IActionResult> GetAllMenu([FromQuery] InputSearchDto inputSearch)
        {
            return Ok(await _menuService.GetAll(inputSearch));
        }

        [HttpGet("menu/{id}")]
        public async Task<IActionResult> GetMenuById(int id)
        {
            return Ok(await _menuService.GetById(id));
        }

        [HttpPost("menu/create")]
        public async Task<IActionResult> CreateMenu([FromForm] MenuDto menuCreate)
        {
            return Ok(await _menuService.Create(menuCreate));
        }

        [HttpPut("menu/update/{id}")]
        public async Task<IActionResult> UpdateMenu(int id, [FromForm] MenuDto menuUpdate)
        {
            return Ok(await _menuService.Update(id, menuUpdate));
        }

        [HttpDelete("menu/delete/{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            return Ok(await _menuService.Delete(id));
        }
        //New API

        //OrderAddress API

        //OrderDetail API

        //Order API

        //ProductCategory API

        //Product API
        [HttpGet("products")]
        public async Task<IActionResult> GetAllProduct([FromQuery] InputSearchDto inputSearch)
        {
            return Ok(await _productService.GetAll(inputSearch));
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await _productService.GetById(id));
        }

        [HttpPost("product/create")]
        public async Task<IActionResult> CreateProduct([FromForm] ProductDto productCreate)
        {
            return Ok(await _productService.Create(productCreate));
        }

        [HttpPut("product/update/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromForm] ProductDto productUpdate)
        {
            return Ok(await _productService.Update(id, productUpdate));
        }

        [HttpDelete("product/delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return Ok(await _productService.Delete(id));
        }
        //Shopcart API

        //Slider API

        //User API
    }
}