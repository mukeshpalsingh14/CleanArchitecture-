using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Order.Application.Dtos;

using Order.Application.Interface.IServices;
using Order.Domain.Entities;
using OrderApp.Middleware;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OrderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        //  public string Name { get; set; }

        public readonly IUserService _userService;  

        public AuthenticateController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDTO userObj)
        {

            try
            {
                if (userObj == null)
                    return BadRequest();
                //User exist check
                //if (await checkUserExist(userObj.Email))
                 //   return BadRequest(new { Message = "User Already exist." });

                if (string.IsNullOrEmpty(userObj.Email)) return NotFound(new { Message = "Mail have required" });
                await _userService.IRegisterUser(userObj);
               // await _appDbContext.SaveChangesAsync();
                return Ok(new
                {
                    Message = "User Registered"
                });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginDTO userObj)
        {
            if(ModelState.IsValid) { 
            if (userObj == null)
                    throw new BadRequestException("keys are not found.");
                var user = await _userService.ILoginUserDetail(userObj);
            if (user == null)
            {
                return NotFound(new { Message = "User Not Found!" });
            }
            user.Token = CreateJWT(user);
            return Ok(new
            {
                token = user.Token,
                Message = "login Success"
            });
            }
            else
            {
                 throw new NotFoundException("User not found.");
            }
        }


        private string CreateJWT(UserDTO user)
        {
            try
            {
                var JwtToken = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("jwt secret key");
                var identity = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Role,user.Role),
                new Claim(ClaimTypes.Name,$"{user.FirstName}:{user.LastName}"),
                });
                var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = identity,
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = credentials,
                };
                var token = JwtToken.CreateToken(tokenDescriptor);
                return JwtToken.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
