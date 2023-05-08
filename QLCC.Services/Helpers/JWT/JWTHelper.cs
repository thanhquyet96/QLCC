﻿using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;

namespace QLCC.Services.Helpers.JWT
{
	//public class JWTHelper
	//{
 //       //public static string GenerateJwtToken(Account account)
 //       //{
 //       //    // generate token that is valid for 15 minutes
 //       //    var tokenHandler = new JwtSecurityTokenHandler();
 //       //    var key = Encoding.ASCII.GetBytes(_appSettings.Secret!);
 //       //    var tokenDescriptor = new SecurityTokenDescriptor
 //       //    {
 //       //        Subject = new ClaimsIdentity(new[] { new Claim("id", account.Id.ToString()) }),
 //       //        Expires = DateTime.UtcNow.AddMinutes(15),
 //       //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
 //       //    };
 //       //    var token = tokenHandler.CreateToken(tokenDescriptor);
 //       //    return tokenHandler.WriteToken(token);
 //       //}

        
 //   }
    public interface IJwtUtils
    {
        public string GenerateJwtToken<T>(T t);
        public int? ValidateJwtToken(string? token);
    }
    public class JwtUtils : IJwtUtils
    {
        //private readonly TContext _context;
        private readonly AppSettings _appSettings;
        private List<Claim> _claims;
        public JwtUtils(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            //_context = context;
            if (string.IsNullOrEmpty(_appSettings.Secret))
                throw new Exception("JWT secret not configured");
            _claims = new List<Claim>();
        }
        public virtual void SetClaims(List<Claim> claims)
        {
            _claims.AddRange(claims);
        }

        public virtual string GenerateJwtToken<T>(T account)
        {
            // generate token that is valid for 15 minutes
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(_claims),
                //Expires = DateTime.UtcNow.AddMinutes(15),
                Expires = DateTime.UtcNow.AddDays(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public virtual int? ValidateJwtToken(string? token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret!);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var accountId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // return account id from JWT token if validation successful
                return accountId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
    }
}

