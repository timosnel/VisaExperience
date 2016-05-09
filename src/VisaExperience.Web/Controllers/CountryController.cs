using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VisaExperience.DataAccess.Repositories.Interfaces;
using VisaExperience.Web.ViewModels;

namespace VisaExperience.Web
{
    [Route("[controller]")]
    public class CountryController : Controller
    {
        private IGeoRepository _geoRepository;

        public CountryController(IGeoRepository geoRepository)
        {
            // if (geoRepository == null) throw new ArgumentNullException(nameof(geoRepository));

            _geoRepository = geoRepository;
        }

        [Route("{id}")]
        public IActionResult Index(string id)
        {
            var viewModel = new CountryViewModel();

            return View(viewModel);
        }
    }
}