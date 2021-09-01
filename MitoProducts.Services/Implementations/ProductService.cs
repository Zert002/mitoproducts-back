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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductDtoRequest> _logger;
        public ProductService(IProductRepository repository, ILogger<ProductDtoRequest> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ResponseDto<int>> CreateAsync(ProductDtoRequest request)
        {
            var response = new ResponseDto<int>();
            try
            {
                var result = await _repository.CreateAsync(new Product
                {
                    CategoryId = request.CategoryId,
                    Name = request.ProductName,
                    UnitPrice = request.ProductPrice,
                    Enabled = request.ProductEnabled
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

        public async Task<ResponseDto<ProductDtoSingleResponse>> GetAsync(int id)
        {
            var response = new ResponseDto<ProductDtoSingleResponse>();
            try
            {
                var product = await _repository.GetItemAsync(id);
                response.Result = new ProductDtoSingleResponse
                {
                    ProductId = product.Id,
                    CategoryId = product.CategoryId,
                    ProductName = product.Name,
                    ProductPrice = product.UnitPrice,
                    ProductEnabled = product.Enabled
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

        public async Task<ProductDtoResponse> GetCollectionAsync(BaseDtoRequest request)
        {
            var response = new ProductDtoResponse();

            var tupla = await _repository.GetCollectionAsync(request.Filter ?? string.Empty, request.Page, request.Rows);

            response.Collection = tupla.collection
                .Select(x => new ProductDto
                {
                    ProductId = x.Id,
                    Category = x.CategoryName,
                    ProductName = x.Name,
                    UnitPrice = x.UnitPrice,
                })
                .ToList();

            response.TotalPages = MitoProductsUtils.GetTotalPages(tupla.total, request.Rows);

            return response;
        }

        public async Task<ResponseDto<int>> UpdateAsync(int id, ProductDtoRequest request)
        {
            var response = new ResponseDto<int>();

            try
            {
                await _repository.UpdateAsync(new Product
                {
                    Id = id,
                    Name = request.ProductName,
                    CategoryId = request.CategoryId,
                    UnitPrice = request.ProductPrice,
                    Enabled = request.ProductEnabled,
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
    }
}
