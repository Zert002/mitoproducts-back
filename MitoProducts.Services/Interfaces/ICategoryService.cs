using MitoProducts.Dto.Request;
using MitoProducts.Dto.Response;
using System.Threading.Tasks;

namespace MitoProducts.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDtoResponse> GetCollectionAsync(BaseDtoRequest request);
        Task<ResponseDto<CategoryDtoSingleResponse>> GetAsync(int id);
        Task <ResponseDto<int>> CreateAsync(CategoryDtoRequest request);
        Task<ResponseDto<int>> UpdateAsync(int id, CategoryDtoRequest request);
        Task<ResponseDto<int>> DeleteAsync(int id);
    }
}