using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using DTO.ResponseDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WikiFashionAPI.Models;

namespace WikiFashionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciesController : ControllerBase
    {
        private readonly IAgenciesManager _AgenciesManager;
        public AgenciesController(IAgenciesManager agenciesManager)
        {
            _AgenciesManager = agenciesManager;
        }
        // GET: api/Agencies
        [HttpGet("", Name = "GetAgencies")]
        public async Task<IActionResult> getAgencies()
        {
            try
            {
                List<AgencyResponseDTO> objResponse = await _AgenciesManager.getAgenciesAsync();
                return Ok(objResponse);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error has occured");

            }
        }

        // GET: api/Agencies/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        
        [HttpPost]
        public async Task<IActionResult> AddAgencyAsync([FromBody] AgencyModel agency)
        {
            try
            {
                bool agence = await _AgenciesManager.AddAgencyAsync(agency.name,agency.link);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }

        }

        // PUT: api/Agencies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
