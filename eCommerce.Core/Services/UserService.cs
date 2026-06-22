using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoriesContract;
using eCommerce.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Services;
internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository,IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<AuthenticationResponse?> Login(LoginRequest request)
    {
      
        ApplicationUser user = await _userRepository.GetUserByEmailandPassword(request.Email, request.Password);
        if (user is null)
        {
            return null;
        }
        return _mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token" };

        //return new AuthenticationResponse(user.UserId, user.Email, user.PersonName, user.Gender, "token", Success: true);
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest request)
    {

        //ApplicationUser user=new ApplicationUser() { Email=request.Email, Password=request.Password, PersonName=request.PersonName, Gender= request.Gender.ToString() };
        ApplicationUser user=_mapper.Map<ApplicationUser>(request);

        ApplicationUser? registerUser= await _userRepository.AddUser(user);

        if (registerUser==null)
        {
            return null;
        }

        return _mapper.Map<AuthenticationResponse>(registerUser) with { Success = true, Token = "token" };
        //return new AuthenticationResponse(registerUser.UserId, registerUser.Email, registerUser.PersonName, registerUser.Gender.ToString(), "token", Success: true);
    }
}

