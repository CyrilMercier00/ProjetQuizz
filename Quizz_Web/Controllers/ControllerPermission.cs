using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizz_Models.Services;
using Quizz_Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizz_Web.Controllers
{
    [ApiController]
    [Route("api/permission")]
    public class ControllerPermission : Controller
    {
        readonly PermissionService permissionService;

        public ControllerPermission()
        {
            permissionService = new PermissionService();
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
