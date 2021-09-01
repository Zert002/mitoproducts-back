using Microsoft.AspNetCore.Mvc;
using MitoProducts.Dto.Response;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using MitoProducts.Services.Interfaces;
using MitoProducts.Entities;
using MitoProducts.Dto.Request;

namespace MitoProductsApi.Controllers
{
    [ApiController]
    [ApiVersion(Constants.V1)]
    [Route(Constants.RouteTemplate)]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        [SwaggerResponse(Constants.Ok, Constants.Aceptado, typeof(ProductDtoResponse))]
        public async Task<IActionResult> List([FromQuery] string filter, int page = 1, int rows = 5)
        {
            return Ok(await _service.GetCollectionAsync(new BaseDtoRequest(filter, page, rows)));
        }
        [HttpGet]
        [Route("{id:int}")]
        [SwaggerResponse(Constants.Ok, Constants.Encontrado, typeof(ResponseDto<ProductDtoSingleResponse>))]
        [SwaggerResponse(Constants.NotFound, Constants.NoEncontrado, typeof(ResponseDto<ProductDtoSingleResponse>))]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _service.GetAsync(id);

            return response.Success ? Ok(response) : NotFound();
        }
        [HttpPost]
        [SwaggerResponse(Constants.Created, Constants.Creado, typeof(int))]
        [SwaggerResponse(Constants.BadRequest, Constants.NoValido)]
        public async Task<IActionResult> Post([FromBody][ModelBinder] ProductDtoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _service.CreateAsync(request);

            if (response.Success)
                return Created($"Product/{response.Result}", response.Result);

            return BadRequest();
        }
        [HttpPut("{id:int}")]
        [SwaggerResponse(Constants.Accepted, Constants.Aceptado, typeof(int))]
        [SwaggerResponse(Constants.NotFound, Constants.NoEncontrado)]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDtoRequest request)
        {
            var response = await _service.UpdateAsync(id, request);
            if (response.Success)
                return Accepted($"Product/{response.Result}");

            return NotFound(id);
        }
        [HttpDelete("{id:int}")]
        [SwaggerResponse(Constants.Accepted, Constants.Aceptado, typeof(int))]
        [SwaggerResponse(Constants.NotFound, Constants.NoEncontrado)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _service.DeleteAsync(id);

            if (response.Success)
                return Accepted();

            return NotFound(id);
        }
    }
}
