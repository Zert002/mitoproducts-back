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

    //[TypeFilter(typeof(FiltroRecurso)]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        //[Route("List")]
        [SwaggerResponse(Constants.Ok,Constants.Aceptado,typeof(CategoryDtoResponse))]
        public async Task<IActionResult> List([FromQuery] string filter, int page = 1, int rows = 5)
        {
            return Ok(await _service.GetCollectionAsync(new BaseDtoRequest(filter,page,rows)));
        }
        //public async Task<CategoryDtoResponse> List([FromQuery] string filter, int page = 1, int rows = 5)
        //{
        //    return await _service.GetCollectionAsync(filter, page, rows);
        //}
        [HttpGet]
        [Route("{id:int}")]
        [SwaggerResponse(Constants.Ok, Constants.Encontrado, typeof(ResponseDto<CategoryDtoSingleResponse>))]
        [SwaggerResponse(Constants.NotFound, Constants.NoEncontrado, typeof(ResponseDto<CategoryDtoSingleResponse>))]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _service.GetAsync(id);

            return response.Success ? Ok(response) : NotFound();
        }
        //public async Task<ResponseDto<CategoryDto>> Get(int id)
        //{
        //    return await _service.GetCategoryAsync(id);
        //}
        [HttpPost]
        [SwaggerResponse(Constants.Created, Constants.Creado, typeof(int))]
        [SwaggerResponse(Constants.BadRequest, Constants.NoValido)]
        public async Task<IActionResult> Post([FromBody][ModelBinder] CategoryDtoRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _service.CreateAsync(request);

            if(response.Success)
                return Created($"Category/{response.Result}", response.Result);

            return BadRequest();
        }
        [HttpPut("{id:int}")]
        [SwaggerResponse(Constants.Accepted, Constants.Aceptado, typeof(int))]
        [SwaggerResponse(Constants.NotFound, Constants.NoEncontrado)]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryDtoRequest request)
        {
            var response = await _service.UpdateAsync(id, request);
            if(response.Success)
                return Accepted($"Category/{response.Result}");

            return NotFound(id);
        }
        [HttpDelete("{id:int}")]
        [SwaggerResponse(Constants.Accepted, Constants.Aceptado, typeof(int))]
        [SwaggerResponse(Constants.NotFound, Constants.NoEncontrado)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _service.DeleteAsync(id);

            if(response.Success)
                return Accepted();

            return NotFound(id);
        }
    }
}
