using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RHAuth.Controllers
{
    [Route(".well-known/apple-app-site-association")]
    public class AppleAppSiteAssociationController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public AppleAppSiteAssociationController(IWebHostEnvironment env)
        {
            _env = env;
        }
        public IActionResult Index()
        {
            string contentRootPath = _env.ContentRootPath;
            return Content(System.IO.File.ReadAllText(contentRootPath + "/wwwroot/deep-linking/apple-app-site-association.json"));
        }
    }
}
