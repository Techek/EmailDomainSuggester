using System;
using Business.Interfaces;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CookieController : Controller
    {
        private readonly string EDSSIDCookieName = "EDSSID";

        private readonly ISidGenerator _sidGenerator;

        public CookieController(ISidGenerator sidGenerator)
        {
            _sidGenerator = sidGenerator;
        }

        [HttpGet]
        [Route("set")]
        public void Set()
        {
            var sid = _sidGenerator.Generate();  

            HttpContext.Response.Cookies.Append(EDSSIDCookieName, sid,
                new CookieOptions()
                {
                    Expires = DateTimeOffset.Now.AddYears(1),
                    HttpOnly = true
                }
            );
        }

        [HttpGet]
        [Route("get")]
        public string Get()
        {
            if (HttpContext.Request.Cookies.ContainsKey(EDSSIDCookieName))
            {
                var sid = HttpContext.Request.Cookies[EDSSIDCookieName];
                return sid;
            }
            else
            {
                return null;
            }
        }
    }
}