using Aviation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Aviation.Controllers
{
    public class AirportController : Controller
    {
        public IActionResult Airport()
        {
            var airport = new Airport();
            return View(airport);
            
        }

        public IActionResult GetAirport(Airport bird)
        {
            try
            {
                var client = new HttpClient();
                var airportURL = "https://airport-info.p.rapidapi.com/airport";
                var airportResponse = client.GetStringAsync(airportURL).Result;
                var airport = JsonConvert.DeserializeObject<Airport>(airportResponse);

                return View(airport);
            }
            catch (Exception ex)
            {

                return View("Airport Not Found");

            }
        }
    }
}
