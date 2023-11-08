using CSharp_App.Interfaces;
using CSharp_App.Models;
using CSharp_App.Services;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelfController : Controller
    {
        private readonly ShelfService _shelfService;

        public ShelfController(IRepository<ShelfModel> shelf)
        {
            _shelfService = new ShelfService(shelf);
        }

        [HttpGet]
        public ActionResult<IList<ShelfModel>> Get() 
        {
            try
            {
                var shelfs = _shelfService.GetAllShelfs();

                if (shelfs != null)
                {
                    return Ok(shelfs);
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
        public ActionResult<ShelfModel> Get([FromRoute] int id) 
        {

            var shelf = _shelfService.GetProductById(id);

            try
            {
                if (shelf != null) 
                {
                    return Ok(shelf);
                }
                else 
                {
                    return NotFound(); 
                }
            }catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }


        [HttpPost]
        public ActionResult Post([FromBody]ShelfModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _shelfService.AddShelf(model);
                var location = new Uri(Request.GetEncodedUrl() + "/" + model.Id);

                return Created(location, model);

            }
            catch(Exception error) 
            {
                return BadRequest(new { message = $"Can't insert this product. More details: {error.Message}" });            
            }

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete([FromRoute] int id, ShelfModel model) 
        {
            var idModel = _shelfService.GetProductById(id);

            if(idModel == null)
            {
               return NotFound();
            }

            try
            {
                _shelfService.DeleteShelf(model);

                return NoContent();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPut("{id:int}")]
        public ActionResult Put([FromRoute] int id,[FromBody] ShelfModel model)
        {
            var idModel = _shelfService.GetProductById(id);

            if (idModel == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                 _shelfService.UpdateShelf(model);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Can't update this product. More details: {error.Message}" });
            }

        }
    }
}
