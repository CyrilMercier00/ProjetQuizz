using Microsoft.AspNetCore.Mvc;
using Quizz_Models.Services;
using Quizz_Models.DTO;
using System.Collections.Generic;

namespace Quizz_Web.Controllers
{
    [ApiController]
    [Route("api/permission")]
    public class ControllerPermission : Controller
    {
        readonly PermissionService permissionService;

        public ControllerPermission(PermissionService prmServicePerm)
        {
            permissionService = prmServicePerm;
        }

        [HttpGet]
        public List<PermissionDTO> Get()
        {
            List<PermissionDTO> permissionDTOs = permissionService.GetPermissions();

            if(permissionDTOs.Count == 0)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
            }

            return permissionDTOs;
        }

        [HttpGet("/names")]
        public List<AffichagePermissionDTO> GetNames()
        {
            List<AffichagePermissionDTO> permissionsNames = this.permissionService.GetPermissionsNames();

            if(permissionsNames.Count == 0)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
            }

            return permissionsNames;
        }

        [HttpPost]
        public void Post(PermissionDTO permissionDTO)
        {
            int lignes = permissionService.AddPermission(permissionDTO);

            if(lignes != 1)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Created;
            }
        }

        [HttpPut("{id}")]
        public void Put(PermissionDTO permissionDTO)
        {
            int lignesmodifiees = permissionService.ModifyPermission(permissionDTO);

            if(lignesmodifiees == 0)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            }
        }
    }
}
