using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtWAspNetCore.Domain;

namespace JwtWAspNetCore.Services.Interfaces
{
    public interface ITokenGenerator
    {
        string CreateJWTToken(User user);
    }
}
