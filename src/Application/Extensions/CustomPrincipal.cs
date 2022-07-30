using System.Security.Claims;

namespace Application.Extensions
{
    public static class CustomPrincipal
    {
        public static string? GetCurrentUserId(this ClaimsPrincipal claims)
        {
            return claims.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}