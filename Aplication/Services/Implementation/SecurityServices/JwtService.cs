using Domain.Entities;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Application.DTO_s;
using Microsoft.AspNetCore.Http;
using Application.Execteptions.Validation;
using Application.Messages.User;
using Application.Services.Abstraction.SecurityServices;
using Application.Constants;
using Application.Messages;

namespace Application.Services.Implementation.SecurityServices
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var _jwt = _configuration.GetSection(SecurityConst.JWT).Get<JwtDto>();
            Claim[]? claims = Array.Empty<Claim>();
            if(string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
                throw new ApiException(MessageErros.ValidationMessage);
            if (!string.IsNullOrEmpty(_jwt?.Subject))
            {
                claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub,_jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(UserConst.USERID, user.UserId.ToString()),
                new Claim(UserConst.EMAIL,user.Email),
                new Claim(UserConst.PASSWORD,user.Password),
                new Claim(UserConst.ROLID,user.RolId.ToString())
            };
            }
            string token = "";
            if (string.IsNullOrEmpty(_jwt?.Key))
                throw new ApiException(MessageErros.ValidationMessage);

            if (!string.IsNullOrEmpty(_jwt.Key))
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
                var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var securityToken = new JwtSecurityToken
                    (
                      _jwt.Issuer,
                      _jwt.Audience,
                      claims,
                      expires: DateTime.Now.AddMinutes(120),
                      signingCredentials: credenciales
                    );

                token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            }
            return token;
        }

        public int GetIdUserInToken(HttpContext context)
        {
            string token = context.Request.Headers[SecurityConst.AUTHORIZATION].ToString().Replace(SecurityConst.BEARER, "");
            if (string.IsNullOrEmpty(token))
                throw new ApiException(MessageUserErrors.NotToken);

            var claims = validatedToken(token);
            var userId = claims.FindFirst(claims => claims.Type == UserConst.USERID);
            if (userId == null)
                throw new ApiException(MessageErros.NotFound);
            return int.Parse(userId.Value);
        }

        private ClaimsPrincipal validatedToken(string token)
        {
            var _jwt = _configuration.GetSection(SecurityConst.JWT).Get<JwtDto>();
            if (string.IsNullOrEmpty(_jwt?.Key))
            {
                throw new ArgumentException(MessageErros.ValidationMessage);
            }
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key)),
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true
            };
            var claimsPrincipal = new JwtSecurityTokenHandler().ValidateToken(token, tokenValidationParameters, out var validatedToken);
            return claimsPrincipal;
        }
    }
}
