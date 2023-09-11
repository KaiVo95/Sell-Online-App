using System.Threading.Tasks;
using WebApiApp.Models;

namespace WebApiApp.Services
{
    public interface ILoginRepository
    {
        Task<ApiResponse> Validate(LoginModel model);
        Task<ApiResponse> RenewToken(TokenModel model);
    }
}
