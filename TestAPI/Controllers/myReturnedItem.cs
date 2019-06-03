using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;
using System.Net.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestAPI.Controllers
{
    [Route("[controller]")]
    public class OrganizationController : Controller
    {
        ReturnedItem item;
        public string organizationCode;
        public string packageName;
        public string AppVersion;
        public string instanceId;


        public OrganizationController()
        {
            item = new ReturnedItem();
            item.apiAppName = "DriversApi";
            item.clientAppId = "3319759c-a7c1-4251-b92d-a3b1a1c1cd80";
            item.organizationDisplayName = "Tenant A";
            item.organizationDomain = "tentant.onmicrosoft.com";
            item.signUpSignInPolicy = "B2C_1_susi";
            item.passwordResetPolicy = "B2C_1_pr";
            item.scopes = "read,write";
        }

       

        [HttpGet("/organization/auth/parameters")]
        public async Task<ActionResult<ReturnedItem>> GetItem()
        {
        
        organizationCode = Request.Headers["organizationCode"];
            packageName = Request.Headers["packageName"];
            AppVersion = Request.Headers["AppVersion"];
            instanceId = Request.Headers["instanceId"];
            if (organizationCode != "3Ag9ku" && packageName != "" && AppVersion != "")
            {
                return NotFound(); 
            }

            else
                return item;
        }
    }
}
