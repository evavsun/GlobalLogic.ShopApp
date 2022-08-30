using GlobalLogic.ShopApp.Api.Models.Products;
using GlobalLogic.ShopApp.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GlobalLogic.ShopApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> Get([FromQuery] int page, [FromQuery] int count)
        {
            var data = await _unitOfWork.Products.GetAllAsync(page, count);
            return Ok(data.Select(x => new ProductResponse(x)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> Get(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product is null)
                return NotFound();
            return Ok(new ProductResponse(product));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductRequest product)
        {
            var newProduct = product.MapToProduct();
            product.ProductImages?.ToList().ForEach(x => newProduct.AddProductImage(x));
            await _unitOfWork.Products.AddAsync(newProduct);
            await _unitOfWork.SaveAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductUpdateRequest product)
        {
            var dbProduct = await _unitOfWork.Products.GetByIdAsync(id);
            if (dbProduct is null)
                return NotFound();
            product.MapToProduct(dbProduct);
            await _unitOfWork.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var dbProduct = await _unitOfWork.Products.GetByIdAsync(id);
            if (dbProduct is null)
                return NotFound();
            _unitOfWork.Products.Remove(dbProduct);
            await _unitOfWork.SaveAsync();
            return Ok();
        }
    }
}
