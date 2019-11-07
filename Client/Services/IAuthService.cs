using System.Threading.Tasks;
using RoleBasedAuthWithBlazorWebAssembly.Shared;

namespace RoleBasedAuthWithBlazorWebAssembly.Client.Services
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
        Task<RegisterResult> Register(RegisterModel registerModel);
    }
}
