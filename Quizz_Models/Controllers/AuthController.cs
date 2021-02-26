﻿using Microsoft.AspNetCore.Mvc;
using Quizz_Models.DTO;
using Quizz_Models.Services;
using Quizz_Models.bdd_quizz;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

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
        public void Login([FromBody] LoginDTO loginDTO)
        {
            Compte compte = this.compteService.FindCompteByMail(loginDTO.Mail);

            if(compte.MotDePasse == loginDTO.MotDePasse)
            {
                // [FRONT -> JWT Decode]
                var mySecret = "Y2VjaWVzdG1vbnNlY3JldA==";
                var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(mySecret));
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.NameIdentifier, compte.PkCompte.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.Sha256)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                string wtoken = tokenHandler.WriteToken(token);
                HttpContext.Session.SetInt32("userId", compte.PkCompte);
            } else
            {
                //Traiter l'erreur de connexion
            }
        }

        [HttpGet]
        [Route("logout")]
        public void Logout()
        {

        }
    }
}
