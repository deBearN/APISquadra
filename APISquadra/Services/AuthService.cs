using APISquadra.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APISquadra.Services
{
    public class AuthService
    {
        

        //public LoginCheck(Userlogin user)



        private static string GerarTokenJWT(string cargo)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Role, cargo)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("93f8207bc2281eebd070f337f907984bfb4ef2d3f1b08689e2e7e16030c8c5e9"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                issuer: "api-autenticacao",
                audience: "api-cadastro",
                claims: claims,
                expires: DateTime.Now.AddHours(17),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public static string TokenUsuario(string Cargo)
        {
            var retorno = GerarTokenJWT(Cargo);
            return retorno;
        }
    }
}
