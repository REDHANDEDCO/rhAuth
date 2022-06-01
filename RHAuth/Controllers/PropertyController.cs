using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RHAuth.Models;
using RHAuth.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static RHAuth.Constants;

namespace RHAuth.Controllers
{
    public class PropertyController : Controller
    {
        public async Task<IActionResult> Index(long? Id)
        {
            var propertyInfo = new PropertyShortInfoDto();
            using (var httpClient = new HttpClient())
            {
                var endPointUrl = ApplicationBaseURL.Staging + APIRequest.GetPropertyDetail + '/' + Id + "?isCrawler=true";
                using (var response = await httpClient.GetAsync(endPointUrl))
                {
                    response.EnsureSuccessStatusCode();
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse != null)
                    {
                        var result = JsonConvert.DeserializeObject<OutputDTO<PropertyShortInfoDto>>(apiResponse.ToString());
                        propertyInfo = result.Data;
                        if (!(propertyInfo is null))
                        {
                            if (!(string.IsNullOrEmpty(propertyInfo.PropertyImage)))
                            {
                                propertyInfo.PropertyImage = Blob.URL + propertyInfo.PropertyImage;
                            }
                            var description = string.Empty;
                            var title = string.Empty;

                            //description = propertyInfo.State + ", " + propertyInfo.City + '\n' + '\n' + propertyInfo.SQFOOTAGE + "/ SQ FT" + '\n' + '\n' + '\t' + '\t' + '\t' + '\t' + "|  $" + propertyInfo.MaxPSF + " /SQ FT";
                            //description = propertyInfo.State + ", " + propertyInfo.City + '\n' + '\n' + propertyInfo.SQFOOTAGE + "/ SQ FT  ," + "$" + propertyInfo.MaxPSF + " /SQ FT";
                            title = "Listed with REDHANDED." + '\n' + '\n' ;
                            ViewBag.FrontEndUrl = ApplicationBaseURL.FrontEndDevUrl;
                            ViewBag.PropertyId = Id;
                            ViewBag.PropertyImage = propertyInfo.PropertyImage;
                            ViewBag.PropertyTitle = title;
                            ViewBag.PropertyDescription = propertyInfo.PropertyName;
                            ViewBag.PropertyUrl = ApplicationBaseURL.FrontEndDevUrl;
                            ViewBag.TitleForURLConversion = propertyInfo.PropertyName;
                        }
                    }
                }
            }

            return View();
        }
    }
}
