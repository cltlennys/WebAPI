

using Core.Auth;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;


namespace Infrastructure.Repositories.Auth;


public class TokenService : ITokenService
{
   
    public string GenerateToken(UsserCredential usserCredential)
    {
        // Los roles que pueden tener son de Admin y Seguridad
        // var userRoles = new List<string> { "Admin" /*, "Seguridad"*/ };
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Name, usserCredential.Name),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
        };
        foreach (var role in usserCredential.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthProperties.SecretKey));
        var signInCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
                AuthProperties.Issuer,
                AuthProperties.Audience,
                claims,
                null,
                DateTime.UtcNow.AddMinutes(AuthProperties.ExpirationTime),
                signInCredentials
        );
        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenValue;
    }
}


