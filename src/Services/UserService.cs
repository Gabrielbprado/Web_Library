using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Web_Library.Models;

namespace Web_Library.Services;

public class UserService
{
    private readonly UserManager<UserModel> _userManager;
    private readonly SignInManager<UserModel> _signInManager;
    private readonly IMemoryCache _memoryCache;
    public UserService(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, IMemoryCache memoryCache)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _memoryCache = memoryCache;
    }

    public async Task<bool> CreateUser(UserModel model)
    {
        var user = new UserModel
        {
            UserName = model.UserName,
            Email = model.Email
        };
        var result = await _userManager.CreateAsync(model, model.Password);
        if (result.Succeeded)
        {
            await _signInManager.PasswordSignInAsync(user.UserName, model.Password,true,false);
            var token = GenerateTokenUser(user);
            _memoryCache.Set(model.UserName, token, TimeSpan.FromDays(30));

            return true;
        }
        return false;
    }

     public async Task<string> LoginUser(UserModel model)
    {
        var loginresult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, false);
        if(!loginresult.Succeeded)
        {
            return null;
        }
        var user = await _userManager.FindByNameAsync(model.UserName);
        string token = GenerateTokenUser(user);

        // Armazena o token JWT na memória usando o nome de usuário como chave
        _memoryCache.Set(model.UserName, token, TimeSpan.FromDays(30));

        return token;
    }

    public string GenerateTokenUser(UserModel model)
    {
        Claim[] claims = new Claim[]
        {
        new Claim("id", model.Id),
        new Claim("username", model.UserName),
        new Claim("email", model.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sdfoijsdfknlsudfls8789ssdadsadsasdadjfhso8d7ofdsjhu"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddDays(30),
            claims: claims,
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GetIdUser(string username)
    {
        UserModel? user = _userManager.FindByNameAsync(username).Result;
        return user.Id;
    }   

    public async Task<bool> LogoutUser()
    {
        try
        {
            await _signInManager.SignOutAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
        
    }
}
