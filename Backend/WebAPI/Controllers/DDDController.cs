
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Services;
using FluentValidation;

namespace API.Controllers
{
    /// <summary>
    /// Web API that handles all relevant HTTP commands.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DDDController : ControllerBase
    {
        private readonly IDDDService _DDDService;

        public DDDController(IDDDService DDDService)
        {
            _DDDService = DDDService;
        }

        [HttpGet(Name = "GetAll")]
        public ActionResult<IEnumerable<DDDItem>> Get()
        {
            try
            {
                var result = _DDDService.GetAllDDDs();
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<DDDItem> Get(int id)
        {
            try
            {
                var result = _DDDService.GetDDD(id);
                if (result == null) { return NotFound(); }
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }

        }

        [HttpPost]
        public ActionResult Post([FromBody] DDDItem DDD)
        {
            try
            {
                _DDDService.CreateDDD(DDD);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] DDDItem DDD)
        {
            try
            {
                bool updateResult = _DDDService.UpdateDDD(DDD);

                if (updateResult)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    // Assuming you want to return a 404 status code if the item to update is not found
                    return NotFound();
                }
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
            catch
            {
                return StatusCode(500);
            }
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (_DDDService.DeleteDDD(id))
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}