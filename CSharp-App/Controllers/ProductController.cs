using CSharp_App.Interfaces;
using CSharp_App.Models;
using CSharp_App.Repository.Context;
using CSharp_App.Services;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc; 

namespace CSharp_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {

        private readonly ProductService _productService;

        public ProductController(IRepository<ProductModel> product)
        {
            _productService = new ProductService(product);
        }


        [HttpGet]
        public ActionResult<IList<ProductModel>> Get()
        {
            var products = _productService.GetAllProducts();

            try
            {
                if (products != null)
                {
                    return Ok(products);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<ProductModel> Get([FromRoute] int id)
        {
            var product = _productService.GetProductById(id);

            try
            {
                if (product != null)
                {
                    return Ok(product);
                }
                else
                {
                    return NotFound();
                }

            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public ActionResult<ProductModel> Post([FromBody] ProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _productService.AddProduct(model);
                var location = new Uri(Request.GetEncodedUrl() + "/" + model.Id);

                return Created(location, model);

            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Can't insert this product. More details: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete([FromRoute] int id, ProductModel model)
        {
            try
            {
                var idModel = _productService.GetProductById(id);

                if (idModel != null)
                {
                    _productService.DeleteProduct(model);

                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
                               
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put([FromRoute] int id,[FromBody] ProductModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if(model.Id != id)
            {
                return NotFound();
            }

            try
            {
                _productService.UpdateProduct(model);
                return NoContent();

            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Can't update this product. More details: {error.Message}" });
            }

            

        }

    }
}
