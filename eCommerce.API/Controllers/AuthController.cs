using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userservice;
    public AuthController(IUserService userService)
    {
        _userservice = userService;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        if(registerRequest is null)
        {
            return BadRequest("Invalid register Data");
        }

        AuthenticationResponse autheres= await _userservice.Register(registerRequest);

        
        if (autheres is null || autheres.Success == false)
        {
            return BadRequest(autheres);
        }
        
        return Ok(autheres);



    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginreq)
    {
        if (loginreq is null)
        {
            return BadRequest("Invalid Data");
        }

        AuthenticationResponse res= await _userservice.Login(loginreq);
        if (res is null || res.Success==false)
        {
            return Unauthorized(res);
        }
        return Ok(res);

    }
}

