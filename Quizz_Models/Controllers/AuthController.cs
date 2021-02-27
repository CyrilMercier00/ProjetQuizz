using Microsoft.AspNetCore.Mvc;
using Quizz_Models.DTO;
using Quizz_Models.Services;
using Quizz_Models.bdd_quizz;
using System.Text.Json;
using System.Security.Claims;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Quizz_Web.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class AuthController : Controller
    {
        readonly CompteService compteService;

        public AuthController(CompteService compteService)
        {
            this.compteService = compteService;
        }

        [HttpPost]
        public string Login([FromBody] LoginDTO loginDTO)
        {
            Compte compte = this.compteService.FindCompteByMail(loginDTO.Mail);

            if (verifyPassword(loginDTO, compte))
            {
                // [FRONT -> JWT Decode]
                return JsonSerializer.Serialize(GenererJWTToken(compte));
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.ServiceUnavailable;
                return "";
                //Traiter l'erreur de connexion
            }
        }

        private string GenererJWTToken(Compte compte)
        {
            var mySecret = "Y2VjaWVzdG1vbnNlY3JldA==";
            var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(mySecret));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                        new Claim("id", compte.PkCompte.ToString()),
                        new Claim("mail", compte.Mail)
                    }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string wtoken = tokenHandler.WriteToken(token);
            return wtoken;
        }

        private bool verifyPassword(LoginDTO loginDTO, Compte compte)
        {
            if(compte != null && compte.MotDePasse == loginDTO.MotDePasse)
            {
                return true;
            }

            return false;
        }

        [HttpGet]
        [Route("logout")]
        public void Logout()
        {

        }
    }
}
