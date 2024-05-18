using Application.Contracts;
using Application.Dtos;
using Application.Services;
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
        private readonly IProductCategoryService _productCategoryService;
        private readonly INewService _newService;
        private readonly IUserService _userService;
        private readonly IOrderAddressService _orderAddressService;
        private readonly IShopCartService _shopCartService;
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;

        public BeaShopController(
            IBrandService brandService,
            IMenuService menuService,
            IProductService productService,
            IProductCategoryService productCategoryService,
            INewService newService,
            IUserService userService,
            IOrderAddressService orderAddressService,
            IShopCartService shopCartService,
            IPaymentMethodService paymentMethodService,
            IOrderService orderService,
            IOrderDetailService orderDetailService
            )
        {
            _brandService = brandService;
            _menuService = menuService;
            _productService = productService;
            _productCategoryService = productCategoryService;
            _newService = newService;
            _userService = userService;
            _orderAddressService = orderAddressService;
            _shopCartService = shopCartService;
            _paymentMethodService = paymentMethodService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }

        //Brand API
        [HttpGet("brands")]
        public async Task<IActionResult> GetAllBrand([FromQuery]InputSearchDto inputSearch)
        {
            return Ok(await _brandService.GetAll(inputSearch));
        }

        [HttpGet("brand/{id}/products")]
        public async Task<IActionResult> GetProductByBrandId(int id, [FromQuery] InputSearchDto inputSearch)
        {
            return Ok(await _brandService.GetProductsByBrandId(id, inputSearch));
        }

        [HttpGet("brand/{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            return Ok(await _brandService.GetById(id));
        }

        [HttpPost("brand/create")]
        public async Task<IActionResult> CreateBrand([FromBody] BrandDto brandCreate)
        {
            return Ok(await _brandService.Create(brandCreate));
        }

        [HttpPut("brand/update/{id}")]
        public async Task<IActionResult> UpdateBrand(int id, [FromBody] BrandDto brandUpdate)
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
        public async Task<IActionResult> CreateMenu([FromBody] MenuDto menuCreate)
        {
            return Ok(await _menuService.Create(menuCreate));
        }

        [HttpPut("menu/update/{id}")]
        public async Task<IActionResult> UpdateMenu(int id, [FromBody] MenuDto menuUpdate)
        {
            return Ok(await _menuService.Update(id, menuUpdate));
        }

        [HttpDelete("menu/delete/{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            return Ok(await _menuService.Delete(id));
        }
        //New API
        [HttpGet("news")]
        public async Task<IActionResult> GetAllNew([FromQuery] InputSearchDto inputSearch)
        {
            return Ok(await _newService.GetAll(inputSearch));
        }

        [HttpGet("new/{id}")]
        public async Task<IActionResult> GetNewById(int id)
        {
            return Ok(await _newService.GetById(id));
        }

        [HttpPost("new/create")]
        public async Task<IActionResult> CreateNew([FromBody] NewDto newCreate)
        {
            return Ok(await _newService.Create(newCreate));
        }

        [HttpPut("new/update/{id}")]
        public async Task<IActionResult> UpdateNew(int id, [FromBody] NewDto newUpdate)
        {
            return Ok(await _newService.Update(id, newUpdate));
        }

        [HttpDelete("new/delete/{id}")]
        public async Task<IActionResult> DeleteNew(int id)
        {
            return Ok(await _newService.Delete(id));
        }

        //OrderAddress API

        [HttpGet("addresses/user/{id}")]
        public async Task<IActionResult> GetAllAddress(string id)
        {
            return Ok(await _orderAddressService.GetAllByUserId(id));
        }

        [HttpGet("address/{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            return Ok(await _orderAddressService.GetById(id));
        }

        [HttpGet("addressv/{id}")]
        public async Task<IActionResult> GetAddressByIdV(int id)
        {
            return Ok(await _orderAddressService.GetByIdV(id));
        }

        [HttpPost("address/create")]
        public async Task<IActionResult> CreateAddress([FromBody] OrderAddressCreateDto orderAddressCreate)
        {
            return Ok(await _orderAddressService.Create(orderAddressCreate));
        }

        [HttpPut("address/update/{id}")]
        public async Task<IActionResult> UpdateAddress(int id, [FromBody] OrderAddressDto orderAddressUpdate)
        {
            return Ok(await _orderAddressService.Update(id, orderAddressUpdate));
        }

        [HttpDelete("address/delete/{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            return Ok(await _orderAddressService.Delete(id));
        }
        //OrderDetail API
        [HttpGet("order-details/order/{id}")]
        public async Task<IActionResult> GetOrderDetailByOrderId(int id)
        {
            return Ok(await _orderDetailService.GetAllByOrderId(id));
        }

        [HttpGet("products-analys")]
        public async Task<IActionResult> GetAllProductToAnalys([FromQuery]InputSearchDto inputSearch)
        {
            return Ok(await _orderDetailService.GetAllProductToAnalys(inputSearch));
        }

        [HttpPost("order-detail/create")]
        public async Task<IActionResult> CreateOrderDetail([FromBody] OrderDetailDto orderDetailCreate)
        {
            return Ok(await _orderDetailService.Create(orderDetailCreate));
        }
        //Order API
        [HttpGet("orders")]
        public async Task<IActionResult> GetAllOrder([FromQuery] InputSearchDto inputSearch)
        {
            return Ok(await _orderService.GetAll(inputSearch));
        }

        [HttpGet("order-statiscal")]
        public async Task<IActionResult> GetOrderStatiscal(string status)
        {
            return Ok(await _orderService.GetOrderStatiscal(status));
        }

        [HttpGet("order-detai/products/order/{id}")]
        public async Task<IActionResult> GetAllOrder(int id)
        {
            return Ok(await _orderService.GetAllProductById(id));
        }

        [HttpGet("orders/user/{id}")]
        public async Task<IActionResult> GetOrderByUserId(string id, [FromQuery] InputSearchDto inputSearch)
        {
            return Ok(await _orderService.GetAllByUserId(id, inputSearch));
        }

        [HttpGet("order/{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            return Ok(await _orderService.GetById(id));
        }

        [HttpPost("order/create")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderCreate)
        {
            return Ok(await _orderService.Create(orderCreate));
        }

        [HttpPut("order/update/{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderUpdateDto orderUpdate)
        {
            return Ok(await _orderService.Update(id, orderUpdate));
        }
        //ProductCategory API
        [HttpGet("categories")]
        public async Task<IActionResult> GetAllCategory([FromQuery] InputSearchDto inputSearch)
        {
            return Ok(await _productCategoryService.GetAll(inputSearch));
        }

        [HttpGet("category/{id}/products")]
        public async Task<IActionResult> GetProductByCateId(int id, [FromQuery] InputSearchDto inputSearch)
        {
            return Ok(await _productCategoryService.GetProductByCateId(id, inputSearch));
        }

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            return Ok(await _productCategoryService.GetById(id));
        }

        [HttpPost("category/create")]
        public async Task<IActionResult> CreateCategory([FromBody] ProductCategoryDto categoryCreate)
        {
            return Ok(await _productCategoryService.Create(categoryCreate));
        }

        [HttpPut("category/update/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] ProductCategoryDto categoryUpdate)
        {
            return Ok(await _productCategoryService.Update(id, categoryUpdate));
        }

        [HttpDelete("category/delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            return Ok(await _productCategoryService.Delete(id));
        }

        //Product API
        [HttpGet("products")]
        public async Task<IActionResult> GetAllProduct([FromQuery] InputSearchDto inputSearch)
        {
            return Ok(await _productService.GetAll(inputSearch));
        }

        [HttpGet("products/user/{id}")]
        public async Task<IActionResult> GetAllByUserId(string id)
        {
            return Ok(await _productService.GetAllByUserId(id));
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await _productService.GetById(id));
        }

        [HttpPost("product/create")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productCreate)
        {
            return Ok(await _productService.Create(productCreate));
        }

        [HttpPut("product/update/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto productUpdate)
        {
            return Ok(await _productService.Update(id, productUpdate));
        }

        [HttpDelete("product/delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return Ok(await _productService.Delete(id));
        }
        //Shopcart API
        [HttpGet("shop-cart/user/{id}")]
        public async Task<IActionResult> GetAllShopCart(string id)
        {
            return Ok(await _shopCartService.GetAllByUserId(id));
        }

        [HttpGet("shop-cart/{id}")]
        public async Task<IActionResult> GetShopCartById(int id)
        {
            return Ok(await _shopCartService.GetById(id));
        }

        [HttpPost("shop-cart/create")]
        public async Task<IActionResult> CreateShopCart([FromBody] ShopCartDto shopCartCreate)
        {
            return Ok(await _shopCartService.Create(shopCartCreate));
        }

        [HttpPut("shop-cart/update/{id}")]
        public async Task<IActionResult> UpdateShopCart(int id, [FromBody] ShopCartUpdateDto shopCartUpdate)
        {
            return Ok(await _shopCartService.Update(id, shopCartUpdate));
        }

        [HttpPut("shop-cart/update/product/{id}")]
        public async Task<IActionResult> UpdateShopCartByProductId(int id, [FromBody] ShopCartUpdateDto shopCartUpdate)
        {
            return Ok(await _shopCartService.UpdateQuantity(id, shopCartUpdate));
        }

        [HttpDelete("shop-cart/delete/{id}")]
        public async Task<IActionResult> DeleteShopCart(int id)
        {
            return Ok(await _shopCartService.Delete(id));
        }

        [HttpDelete("shop-cart/delete/product/{id}")]
        public async Task<IActionResult> DeleteShopCartByProductId(int id)
        {
            return Ok(await _shopCartService.DeleteByProductId(id));
        }
        //Slider API

        //PaymentMethod API
        [HttpGet("payments")]
        public async Task<IActionResult> GetAllPayment()
        {
            return Ok(await _paymentMethodService.GetAll());
        }

        [HttpGet("payment/{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            return Ok(await _paymentMethodService.GetById(id));
        }
        //UploadFile API
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile fileImage)
        {
            if (fileImage.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileImage.FileName);
                using (var stream = System.IO.File.Create(path))
                {
                    await fileImage.CopyToAsync(stream);
                }
                return Ok(fileImage.FileName);
            }
            return Ok("Co loi xay ra");
        }


        //User API
        [HttpPost("login")]
        public async Task<IActionResult> SignIn([FromBody] UserLoginDto model)
        {
            return Ok(await _userService.LoginAsync(model));
        }

        [HttpPost("register")]
        public async Task<IActionResult> SignUp([FromBody] UserRegisterDto model)
        {
            return Ok(await _userService.RegisterAsync(model));
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAll([FromQuery] InputSearchDto inputSearchDto)
        {
            return Ok(await _userService.GetAll(inputSearchDto));
        }
    }
}