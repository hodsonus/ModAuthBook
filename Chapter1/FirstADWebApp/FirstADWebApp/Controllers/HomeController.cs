using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using ClaimTypes = System.IdentityModel.Claims.ClaimTypes;

namespace FirstADWebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ClaimsPrincipal cp = ClaimsPrincipal.Current;
            string welcome = string.Format(
                "Welcome, {0} {1}!",
                cp.FindFirst(ClaimTypes.GivenName).Value,
                cp.FindFirst(ClaimTypes.Surname).Value);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}