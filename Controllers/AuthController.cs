using Microsoft.AspNetCore.Mvc;
using test_crud.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using test_crud.Entity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System;

namespace test_crud.Controllers
{

    public class Token
    {
        public string Access_token { get; set; }
        public string Refresh_token { get; set; }
        public int ID { get; set; }

    };

    public class TokenRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string GrantType { get; set; }
        public string Refresh_token { get; set; }
    };

    [ApiController]
    [Route("AuthController")]
    public class AuthController : ControllerBase
    {

        private readonly ApplicationContext context;
        private readonly IOptions<AuthOptions> authOptions;
        public AuthController(IOptions<AuthOptions> _authOptions, ApplicationContext _context)
        {
            context = _context;
            this.authOptions = _authOptions;
        }


        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] TokenRequest request)
        {
            switch (request.GrantType)
            {
                case "password":
                 var user = AuthentificateUser(request.Email, request.Password); 

                    if (user != null)
                    {
                        var token = GenerateJWT(user);
                        return Ok(token);
                    }

                    return Unauthorized();


                case "refreshtoken":
                    if (string.IsNullOrEmpty(request.Refresh_token)) throw new Exception("Bad refresh_token format");

                    var authParams = authOptions.Value;

                    var tokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidAudience = "Refresh",
                        ValidateIssuer = true,
                        ValidIssuer = authParams.Issuer,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = authParams.GetSymmetricSecurityKey(),
                        ValidateLifetime = true
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    try
                    {
                        var principal = tokenHandler.ValidateToken(request.Refresh_token, tokenValidationParameters, out var securityToken);
                        var jwtSecurityToken = securityToken as JwtSecurityToken;
                        if (jwtSecurityToken == null||!jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                          StringComparison.InvariantCultureIgnoreCase))
                             throw new SecurityTokenException("Invalid token");

                        var loggedUser = context.UsersTable.FirstOrDefault(x => x.Mail == request.Email);
                        if (loggedUser == null)
                        {
                            throw new Exception("Wrong login or the user name is locked");
                        }

                        return Ok(GenerateJWT(loggedUser));
                    }
                    catch (Exception ste) when (ste is SecurityTokenExpiredException)
                    {
                        throw new Exception("The token has expired. Please login.");
                    }

                    catch (Exception ste)
                    {
                        throw new Exception(ste.Message);
                    }

                default:
                    throw new Exception("Invalid Grant Type");
            }
        } 

        private User AuthentificateUser(string email, string password)
        {
            return context.UsersTable.FirstOrDefault(x => x.Mail == email && x.Password == password);
        }

        private Token GenerateJWT(User _user)
        {
            var authParams = authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
            new Claim(JwtRegisteredClaimNames.Email, _user.Mail),
            new Claim(JwtRegisteredClaimNames.Sub, _user.ID.ToString()),
            };


            var token = new Token();

            var accesstoken = new JwtSecurityToken(authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentials);

            var JWTAccessToken = new JwtSecurityTokenHandler().WriteToken(accesstoken);

            var refreshJwt = new JwtSecurityToken(
                 authParams.Issuer,
                 "Refresh",
                 notBefore: DateTime.Now,
                 claims: claims,
                 expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                 signingCredentials: credentials);

            var JWTRefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshJwt);

            token.Access_token = JWTAccessToken;
            token.Refresh_token = JWTRefreshToken;
            token.ID = _user.ID;
            return token;
        }
    }
}
