

using Core.Entities;
using System.Security.Claims;

namespace Core.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(UsserCredential usserCredential);
    }
}
