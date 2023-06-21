using MovieReview.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace MovieReview.API.Extensions
{
    public static class RoleClaimsExtension
    {
        public static IEnumerable<Claim> GetClaims(this Reviwer paramReviwer) 
        {
            List<Claim> result;
            if (paramReviwer.ISADMINISTRATOR == 1)
            {
                result = new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, Convert.ToString(paramReviwer.ID)),
                    new(ClaimTypes.Name, paramReviwer.NAME),
                    new(ClaimTypes.Role, "Admin")                   
                };
            }
            else 
            {
                result = new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, Convert.ToString(paramReviwer.ID)),
                    new(ClaimTypes.Name, paramReviwer.NAME),
                    new(ClaimTypes.Role, "Reviwer")
                };
            }

            return result;
        }
    }
}
