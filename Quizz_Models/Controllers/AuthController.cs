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
        readonly PermissionService permissionService;

        public AuthController(CompteService compteService, PermissionService permissionService)
        {
            this.compteService = compteService;
            this.permissionService = permissionService;
        }

        [HttpPost]
        public string Login([FromBody] LoginDTO loginDTO)
        {
            Compte compte = this.compteService.FindCompteByMail(loginDTO.Mail);

            if (compte != null && VerifyPassword(loginDTO, compte))
            {
                PermissionDTO permissionDTO = this.compteService.GetCurrentComptePermission(compte.PkCompte);
                if(permissionDTO != null)
                {
                    return JsonSerializer.Serialize(GenererJWTToken(compte, permissionDTO));
                }
                else
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.ServiceUnavailable;
                    return "";
                }
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.ServiceUnavailable;
                return "";
            }
        }

        private string GenererJWTToken(Compte compte, PermissionDTO permissionDTO)
        {
            var mySecret = "Y2VjaWVzdG1vbnNlY3JldA==";
            var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(mySecret));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                        new Claim("id", compte.PkCompte.ToString()),
                        new Claim("mail", compte.Mail),
                        new Claim("nom", compte.Nom),
                        new Claim("prenom", compte.Prenom),
                        new Claim("role", permissionDTO.Nom),
                        new Claim("GenererQuizz", permissionDTO.GenererQuizz.ToString()),
                        new Claim("AjouterQuest", permissionDTO.AjouterQuest.ToString()),
                        new Claim("ModifierQuest", permissionDTO.ModifierQuest.ToString()),
                        new Claim("SupprQuestion", permissionDTO.SupprQuestion.ToString()),
                        new Claim("ModifierCompte", permissionDTO.ModifierCompte.ToString()),
                        new Claim("SupprimerCompte", permissionDTO.SupprimerCompte.ToString())
                    }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string wtoken = tokenHandler.WriteToken(token);
            return wtoken;
        }

        private bool VerifyPassword(LoginDTO loginDTO, Compte compte)
        {
            string mdpEntreeCrypte = ControllerCompte.computePassword(loginDTO.MotDePasse);
            if(compte != null && compte.MotDePasse == mdpEntreeCrypte)
            {
                return true;
            }

            return false;
        }
    }
}
