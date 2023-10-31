using System.Security.Claims;

namespace Blog.Extensions;

internal static class UserExtensions
{
    public static IEnumerable<Claim> GetClaims(this User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Email)
        };

        claims.AddRange(user
            .Roles
            .Select(role => new Claim(ClaimTypes.Role, role.Slug)));

        return claims;
    }
}
