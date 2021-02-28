using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Collections.Generic;
using Quizz_Models.Authentification;
using Quizz_Models.bdd_quizz;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly IList<AuthorizationEnum> authorizations;

    public AuthorizeAttribute(params AuthorizationEnum[] authorizations)
    {
        this.authorizations = authorizations;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var compte = (Compte)context.HttpContext.Items["Compte"];
        var permission = (Permission)context.HttpContext.Items["Permission"];

        if (compte == null || (this.authorizations.Any() && !Authorized(permission)))
        {
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }

    private bool Authorized(Permission p)
    {
        bool authorized = false;

        foreach(AuthorizationEnum authorization in this.authorizations)
        {
            if(authorization == AuthorizationEnum.AjouterQuest && (p.AjouterQuest != 0))
            {
                authorized = true;
            } else if(authorization == AuthorizationEnum.GenererQuizz && (p.GenererQuizz != 0))
            {
                authorized = true;
            } else if(authorization == AuthorizationEnum.ModifierCompte && (p.ModifierCompte != 0))
            {
                authorized = true;
            } else if(authorization == AuthorizationEnum.ModifierQuest && (p.ModifierQuest != 0))
            {
                authorized = true;
            } else if(authorization == AuthorizationEnum.SupprimerCompte && (p.SupprimerCompte != 0))
            {
                authorized =  true;
            } else if(authorization == AuthorizationEnum.SupprQuestion && (p.SupprQuestion != 0))
            {
                return true;
            }
        }

        return authorized;
    }
}