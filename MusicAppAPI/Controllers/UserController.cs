using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MusicAppAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

/*
Contains user related api methods in addition to supplementary methods linked to tokens and encoding
*/


namespace MusicAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly SecurityHelper _securityHelper;

        public UserController(DataContext context, IConfiguration configuration, IUserService userService, SecurityHelper securityHelper)
        {
            _context = context;
            _configuration = configuration;
            _userService = userService;
            _securityHelper = securityHelper; //helper class for auth methods - not actively used
        }

        //remnant of attempted authorization
        [HttpGet("getMe"), Authorize]
        public ActionResult<object> getMe()
        {
            var userID = _userService.getMyID();
            return Ok(userID);
        }


        //method to add user to database
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            if (_context.Users.Any(u => u.Username == request.Username))
            {
                return BadRequest();
            }

            _securityHelper.CreatePasswordHash(request.Password,
                    out byte[] passwordHash,
                    out byte[] passwordSalt);

            var user = new User
            {
                Username = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                //VerificationToken = CreateRandomToken()
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
        }


        //method for logging in user - token is left over from authorization attempts however i left it to show it was meant to be used
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);

            if(user == null) { return BadRequest("User not found!"); }

            if (!_securityHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Password is incorrect!");
            }

            AuthenticatedRespones token = _securityHelper.CreateToken(user);
            return Ok(user.Id);
        }

        //autogen code

        // gets all users, not use in web app just in swagger
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            return await _context.Users.ToListAsync();
        }

        
    }
}
