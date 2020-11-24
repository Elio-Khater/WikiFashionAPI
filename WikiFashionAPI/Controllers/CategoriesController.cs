using BLL.Interfaces;
using DTO.ResponseDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WikiFashionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesManager _CategoriesManager;
        public CategoriesController(ICategoriesManager categoriesManager)
        {
            _CategoriesManager = categoriesManager;
        }
        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                List<CategoryResponseDTO> objResponse = await _CategoriesManager.GetListOfCategoriesAsync();
                return Ok(objResponse);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured");
            }

        }

        [HttpGet("/adfilters", Name = "GetAdvancedFilters")]
        public async Task<IActionResult> GetAdvancedFilters(int id, [FromBody] int agency, string eyes, string skin)
        {
            try
            {
                List<CategoryResponseDTO> objResponse = await _CategoriesManager.GetAdvancedFiltersAsync(id, agency, eyes);
                return Ok(objResponse);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured");
            }

        }

        // GET: api/Categories/5
        [HttpGet("{id}", Name = "GetCategoryById")]
        public string Get(int id)
        {
            return "value";
        }

        // GET: api/Categories/{id}/users
        [HttpGet("{id}/users", Name = "GetUsersByCategories")]
        public async Task<IActionResult> GetUsersAsync(int id, [FromQuery] string filters, int section, string eyes, int agency)
        {
            try
            {
                List<string> filtersArr = new List<string>();
                if (filters != null)
                {
                    filtersArr = filters.Split(",").ToList();
                }
                if (eyes == null)
                {
                    eyes = "";
                }
               
                List<UserResponseDTO> objResponse = await _CategoriesManager.GetUserByCategoryAsync(id, filtersArr, section, eyes, agency);
                return Ok(objResponse);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error has occured");

            }
        }



        // POST: api/Categories
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Categories/5
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
