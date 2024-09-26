using AuthService.Dto;
using AuthService.Model;
using AuthService.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        private readonly IMapper _mapper;

        private readonly ResponseDto _responseDto;
        
        private readonly IConfiguration _configuration;

        
        public AuthController(IAuthService authService,IMapper mapper,IConfiguration configuration)
        {
            _authService = authService;
            _mapper = mapper;
            _responseDto = new ResponseDto();
            _configuration = configuration;  
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetOneUser(string SubOid)
        {
               var user = await  _authService.GetUser(SubOid);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
        }


        [HttpPost("RegisterUser")]
        public async Task<ActionResult<string>> RegisterUser(RegisterUserDto userDto)
        {
            try
            {
                //Check the user if already exist in the db
                var user = await _authService.GetUser(userDto.SubOid);
                Console.WriteLine(user);
                if (user == null)
                {
                string resp = await _authService.RegisterUser(userDto);
                if(string.IsNullOrEmpty(resp))
                {
                    _responseDto.Message = "User created successfully";
                    _responseDto.result = userDto;
                    _responseDto.statusCode = HttpStatusCode.OK;
                    return Created("", _responseDto);
                }
                else
                {
                    _responseDto.Message = "something went worng";
                    return BadRequest(_responseDto);
                }
                }
                else
                {
                    return $"user {user.UserName} does exists";
                }
            }catch(Exception ex)
            {
                _responseDto.Message= ex.Message;
                return BadRequest(_responseDto);
            }
        }
    }
}
