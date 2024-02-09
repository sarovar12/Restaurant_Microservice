﻿using static Restaurant.Web.Standard;

namespace Restaurant.Web.Models
{
    public class RequestHandler
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string URL { get; set; }
        public object Data {  get; set; }
        public string AccessToken { get; set; }
    }
}
