using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GooglePlusAuthProviderDemo.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            if (Request.IsAuthenticated)
            {
                var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
                var claims = claimsIdentity.Claims;

                var accessTokenClaim = claims.FirstOrDefault(x => x.Type == Startup.GooglePlusAccessTokenClaimType);

                if (accessTokenClaim != null)
                {
                    string url = "https://www.googleapis.com/plus/v1/people/me?access_token=" + Uri.EscapeDataString(accessTokenClaim.Value);

                    var client = new HttpClient();
                    var response = await client.GetAsync(url);

                    ViewBag.GooglePlusUserInfo = await response.Content.ReadAsStringAsync();
                }
            }

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