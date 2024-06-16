using Microsoft.AspNetCore.Mvc;
using CarRental.SharedKernel.Dto;
using CarRental.Application.IServices;

namespace AutoPartRental.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoPartController : Controller
    {
        private readonly IAutoPartService _autoPartService;
        private readonly ILogger<AutoPartController> _logger;

        public AutoPartController(IAutoPartService productService, ILogger<AutoPartController> logger)
        {
            this._autoPartService = productService;
            this._logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AutoPartDto>> Get()
        {
            var result = _autoPartService.GetAll();
            _logger.LogDebug("Pobrano listę wszystkich produktów");
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetAutoPart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AutoPartDto> Get(int id)
        {
            var result = _autoPartService.GetById(id);
            _logger.LogDebug($"Pobrano produkt o id = {id}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create([FromBody] AutoPartDto dto)
        {
            var id = _autoPartService.Create(dto);

            _logger.LogDebug($"Utworzono nowy produkt z id = {id}");
            var actionName = nameof(Get);
            var routeValues = new { id };
            return CreatedAtAction(actionName, routeValues, null);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            _autoPartService.Delete(id);
            _logger.LogDebug($"Usunieto produkt z id = {id}");
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update(int id, [FromBody] AutoPartDto dto)
        {
            if (id != dto.Id)
            {
                //throw new BadRequestException("Id param is not valid");
            }

            _autoPartService.Update(dto);
            _logger.LogDebug($"Zaktualizowano produkt z id = {id}");
            return NoContent();
        }
    }
}