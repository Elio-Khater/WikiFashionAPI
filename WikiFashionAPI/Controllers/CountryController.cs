using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using DTO.ResponseDTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WikiFashionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryManager _CountryManager;
        public CountryController(ICountryManager countryManager)
        {
            _CountryManager = countryManager;
        }
        // GET: api/countries
        [HttpGet("", Name = "GetCountries")]
        public async Task<IActionResult> getCountries()
        {
            try
            {
                List<CountryResponseDTO> objResponse = await _CountryManager.getCountriesAsync();
                return Ok(objResponse);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error has occured");

            }
        }
    }
}
