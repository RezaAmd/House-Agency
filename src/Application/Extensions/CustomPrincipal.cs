namespace System.Security.Claims
{
    public static class CustomPrincipal
    {
        public static string? GetCurrentUserId(this ClaimsPrincipal claims)
        {
            return claims.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}