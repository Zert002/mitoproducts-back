using MitoProducts.DataAccess.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using MitoProducts.Dto.Request;
using MitoProductos.Entities;
using Microsoft.Extensions.Logging;
using MitoProducts.Dto.Response;
using MitoProducts.Services.Interfaces;
using MitoProducts.Services.Utils;

namespace MitoProducts.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly ILogger<CategoryDtoRequest> _logger;

        public CategoryService(ICategoryRepository repository, ILogger<CategoryDtoRequest> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<CategoryDtoResponse> GetCollectionAsync(BaseDtoRequest request)
        {
            var response = new CategoryDtoResponse();

            var tupla = await _repository.GetCollectionAsync(request.Filter ?? string.Empty, request.Page, request.Rows);

            response.Collection = tupla.collection
                .Select(p => new CategoryDtoSingleResponse()
                {
                    CategoryId= p.Id,
                    CategoryName = p.Name,
                    CategoryDescription = p.Description
                }).ToList();

            response.TotalPages = MitoProductsUtils.GetTotalPages(tupla.total, request.Rows);

            return response;
        }

        public async Task<ResponseDto<CategoryDtoSingleResponse>> GetAsync(int id)
        {
            var response = new ResponseDto<CategoryDtoSingleResponse>();
            try
            {
                var category = await _repository.GetItemAsync(id);
                response.Result = new CategoryDtoSingleResponse
                {
                    CategoryId = category.Id,
                    CategoryName = category.Name,
                    CategoryDescription = category.Description
                };
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                response.Success = false;
            }

            return response;
        }
        public async Task<ResponseDto<int>> CreateAsync(CategoryDtoRequest request)
        {
            var response = new ResponseDto<int>();
            try
            {
                var result = await _repository.CreateAsync(new Category
                {
                    Name = request.Name,
                    Description = request.Description
                });
                response.Result = result;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                response.Success = false;
            }
            return response;
        }

        public async Task<ResponseDto<int>> UpdateAsync(int id, CategoryDtoRequest request)
        {
            var response = new ResponseDto<int>();
            try
            {
                await _repository.UpdateAsync(new Category
                {
                    Id = id,
                    Name = request.Name,
                    Description = request.Description
                });
                response.Result = id;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                response.Success = false;
            }
            return response;
        }

        public async Task<ResponseDto<int>> DeleteAsync(int id)
        {
            var response = new ResponseDto<int>();
            try
            {
                await _repository.DeleteAsync(id);

                response.Result = id;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                response.Success = false;
            }

            return response;
        }
    }
}
