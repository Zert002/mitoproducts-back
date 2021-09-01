using MitoProducts.Dto.Request;
using MitoProducts.Dto.Response;
using System.Threading.Tasks;

namespace MitoProducts.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductDtoResponse> GetCollectionAsync(BaseDtoRequest request);
        Task<ResponseDto<ProductDtoSingleResponse>> GetAsync(int id);
        Task<ResponseDto<int>> CreateAsync(ProductDtoRequest request);
        Task<ResponseDto<int>> UpdateAsync(int id, ProductDtoRequest request);
        Task<ResponseDto<int>> DeleteAsync(int id);
    }
}
