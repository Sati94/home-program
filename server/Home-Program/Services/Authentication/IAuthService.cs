using Home_Program.Model.User;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Home_Program.Services.Authentication
{
    public interface IAuthService
    {
        Task<IActionResult> Login(LoginModel model);
        Task<IActionResult> Register(RegisterModel model);
    }
}
