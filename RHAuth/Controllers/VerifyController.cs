using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RHAuth.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static RHAuth.Enums;

namespace RHAuth.Controllers
{
    public class VerifyController : Controller
    {
        public async Task<IActionResult> Index(string email, string token, long? roleId)
        {
            var verifyData = new { email=  email, token = token};
            OutputDTO<string> finalData = new OutputDTO<string>();

            //string apiBaseUrl = "http://redhanded-dev-be.azurewebsites.net/";
            string apiBaseUrl = "https://redhandedapi.azurewebsites.net/";

            using (var httpClient = new HttpClient())
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(verifyData), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(apiBaseUrl + "api/login/email/verify",  content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if(apiResponse != null)
                    {
                        finalData = JsonConvert.DeserializeObject<OutputDTO<string>>(apiResponse.ToString());
                    }
                    ViewBag.VerifiedData = finalData;
                }
            }
            if (roleId.HasValue)
            {
                if (roleId == (int)RolesEnums.Tenant)
                {
                    ViewBag.RedirectUrl = "thankyou-tenant";
                }
                else if (roleId == (int)RolesEnums.LandLord)
                {
                    ViewBag.RedirectUrl = "thankyou-landlord";
                }
            }
            return View("EmailVerify");
        }
    }
}
