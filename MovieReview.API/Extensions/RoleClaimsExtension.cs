using MovieReview.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace MovieReview.API.Extensions
{
    public static class RoleClaimsExtension
    {
        public static IEnumerable<Claim> GetClaims(this User paramUser) 
        {
            List<Claim> result;
            if (paramUser.IsAdministrator)
            {
                result = new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, Convert.ToString(paramUser.Id)),
                    new(ClaimTypes.Name, paramUser.Name),
                    new(ClaimTypes.Email, paramUser.Email),
                    new(ClaimTypes.Role, "Admin")                   
                };
            }
            else 
            {
                result = new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, Convert.ToString(paramUser.Id)),
                    new(ClaimTypes.Name, paramUser.Name),
                    new(ClaimTypes.Email, paramUser.Email),
                    new(ClaimTypes.Role, "Common")
                };
            }

            return result;
        }
    }
}
