using RoleBasedAuthWithBlazorWebAssembly.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace RoleBasedAuthWithBlazorWebAssembly.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private static UserModel LoggedOutUser = new UserModel { IsAuthenticated = false };

        private readonly UserManager<IdentityUser> _userManager;

        public AccountsController(UserManager<IdentityUser> userManager) {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegisterModel model) {
            var newUser = new IdentityUser { UserName = model.Email, Email = model.Email };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded) {
                var errors = result.Errors.Select(x => x.Description);

                return BadRequest(new RegisterResult { Successful = false, Errors = errors });

            }

            //为所有的新用户分配User角色
            await _userManager.AddToRoleAsync(newUser, "User");

            //如果电子邮件以'admin'开头则分配Admin角色
            if (newUser.Email.StartsWith("admin")) {
                await _userManager.AddToRoleAsync(newUser, "Admin");
            }

            return Ok(new RegisterResult { Successful = true });
        }
    }
}