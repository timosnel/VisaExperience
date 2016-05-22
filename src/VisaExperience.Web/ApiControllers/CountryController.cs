using System;
using Microsoft.AspNetCore.Mvc;
using VisaExperience.DataAccess.Repositories.Interfaces;

namespace VisaExperience.Web.ApiControllers
{
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private IGeoRepository _geoRepository;

        public CountryController(IGeoRepository geoRepository)
        {
            if (geoRepository == null) throw new ArgumentNullException(nameof(geoRepository));

            _geoRepository = geoRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetCountry(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();

            string country = "example";
            
            return new ObjectResult(country);
        }
    }
}
