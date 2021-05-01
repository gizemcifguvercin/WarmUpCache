using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarmUpCache.Services;

namespace WarmUpCache.Controllers
{ 
    [ApiController]
    public class CityController : ControllerBase
    { 
        private ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        
        [HttpGet("cities")]
        public async Task<IActionResult> Get()
        {
           var cityList = _cityService.GetCityList();
           return Ok(cityList);
        }
    }
}
