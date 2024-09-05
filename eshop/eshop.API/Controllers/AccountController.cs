using eshop.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IUserService service) : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(UserLoginInfo userLogin)
        {
            //Amaç: Kişiyi doğrula. Ve Token gönder!
            if (ModelState.IsValid)
            {
                var user = service.ValidateUser(userLogin.UserName, userLogin.Password);
                if (user != null)
                {
                    SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("donulmez-aksamin-ufkundayiz-vakit-cok-gec"));
                    SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var claims = new Claim[]
                    {
                        new Claim(JwtRegisteredClaimNames.Name,user.UserName),
                        new Claim("takim","fb-gs-bjk"),
                        new Claim("Role",user.Role)

                    };

                    var token = new JwtSecurityToken(
                        issuer: "tarimkredi.server",
                        audience: "tarimkredi.client",
                        claims: claims,
                        notBefore: DateTime.Now,
                        expires: DateTime.Now.AddYears(1),
                        signingCredentials: signingCredentials
                        );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });


                }
                ModelState.AddModelError("failed", "Kullanıcı adı veya şifre yanlış");
            }

            return BadRequest(ModelState);
        }


    }
}
