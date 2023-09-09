using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HexagonalArchitecture.Domain.Adapters.Authorization;
using HexagonalArchitecture.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace HexagonalArchitecture.Adapter.Authorization
{
    public class TokenService : ITokenService
    {
        private const int ExpirationMinutes = 30;
        private byte[] SigningKey { get; set; }
        private string Issuer { get; set; }
        private string Audience { get; set; }

        public TokenService(byte[] signingKey, string issuer, string audience)
        {
            SigningKey = signingKey;
            Issuer = issuer;
            Audience = audience;
        }

        public ClaimsPrincipal GetTokenClaimsPrincipal(string token)
        {
            if (token != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                var identity = new ClaimsIdentity(jwtToken.Claims, "jwt");

                var principal = new ClaimsPrincipal(identity);

                return principal;
            }

            return null;
        }

        public string CreateToken(User user, UserType userType = UserType.Default)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            var expiration = DateTime.UtcNow.AddMinutes(ExpirationMinutes);

            var token = new JwtSecurityToken(
               issuer: Issuer,
               audience: Audience,
               claims: CreateClaims(user, userType),
               expires: expiration,
               signingCredentials: CreateSigningCredentials()
            );

            return tokenHandler.WriteToken(token);
        }

        private JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials, DateTime expiration)
        {
            return new JwtSecurityToken(claims: claims, expires: expiration, signingCredentials: credentials);
        }

        private List<Claim> CreateClaims(User user, UserType userType)
        {
            var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString(), ClaimValueTypes.Integer64),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
            new Claim("user_name", user.Name.ToString()),
            new Claim("user_username", user.Username.ToString()),
            new Claim("user_email", user.Email.ToString()),
            new Claim("user_role", UserType.Default.ToString()),
        };

            if (userType == UserType.Administrator)
                claims.Add(new Claim(ClaimTypes.Role, userType.ToString()));

            claims.Add(new Claim("user_is_admin", (userType == UserType.Administrator).ToString().ToLower(), ClaimValueTypes.Boolean));

            return claims;
        }

        private SigningCredentials CreateSigningCredentials()
        {
            return new SigningCredentials(new SymmetricSecurityKey(SigningKey), SecurityAlgorithms.HmacSha256);
        }
    }
}
