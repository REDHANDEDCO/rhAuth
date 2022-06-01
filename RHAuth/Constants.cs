using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RHAuth
{
    public static class Constants
    {
        public static class ApplicationBaseURL
        {
            public const string Staging = "http://redhanded-dev-be.azurewebsites.net/api";
            public const string Production = "https://redhandedapi.azurewebsites.net/api";
            public const string FrontEndDevUrl = "https://redhanded.azurewebsites.net/";
            public const string FrontEndProdUrl = "https://redhandedco.com/";
        }

        public static class Blob
        {
            public const string URL = "https://redhandedstorage.blob.core.windows.net/assets";
        }

        public static class APIRequest
        {
            public const string GetPropertyDetail = "/property/get/shortDetail";
        }
    }
}
