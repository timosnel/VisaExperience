using Microsoft.AspNetCore.Mvc;

namespace VisaExperience.Web
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index() => View();
    }
}