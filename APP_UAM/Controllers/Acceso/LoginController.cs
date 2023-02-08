using APP_UAM.Entities.Usuario;
using APP_UAM.Interfaces.Usuario;
using APP_UAM.Logic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace APP_UAM.Controllers.Acceso
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoginController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            /*---------------------------------- Se busca IdUsuario en cookies -----------------------------*/
            var user = new HttpContextAccessor()?.HttpContext?.User;
            var correo = user?.Claims.Where(x => x.Type == "FullName").Select(x => x.Value).FirstOrDefault();

            /*-------------------------- No se encontro un usuario autenticado -----------------------------*/
            if (String.IsNullOrEmpty(correo))
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
        [Route("Login/Acceder")]
        [HttpPost]
        public async Task<IActionResult> Acceder(Usuario usuario)
        {
            Usuario? user = await Login.SetLogin(usuario);
            if (user == null)
            {
                return Ok(new {
                    Error = true
                    });
            }

            var claims = new List<Claim>
            {
                new Claim("FullName", user.Correo)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = false,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                RedirectUri = "/Home",
                IsPersistent = false
        };
            await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(principal),
                    authProperties);
            return Ok(new
            {
                Result = user,
                Error = false
            });
        }
    }
}
