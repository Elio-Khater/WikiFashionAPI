using BLL.Interfaces;
using DTO.RequestDTO;
using DTO.ResponseDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WikiFashionAPI.Models;

namespace WikiFashionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersManager _UsersManager;
        private readonly IAgenciesManager _AgenciesManager;

        public UsersController(IUsersManager usersManager, IAgenciesManager agenciesManager)
        {
            _UsersManager = usersManager;
            _AgenciesManager = agenciesManager;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                List<UserResponseDTO> objResponse = await _UsersManager.GetUsersAsync();
                return Ok(objResponse);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error has occured");

            }
        }

        // GET: api/users/{id}
        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                UserResponseDTO objResponse = await _UsersManager.GetUserByIdAsync(id);
                return Ok(objResponse);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error has occured");

            }
        }
        // GET: api/users/{id}/agencies
        [HttpGet("{id}/agencies", Name = "GetAgenciesById")]
        public async Task<IActionResult> GetAgenciesById(int id)
        {
            try
            {
                List<AgencyResponseDTO> objResponse = await _UsersManager.GetAgenciesByIdAsync(id);
                return Ok(objResponse);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error has occured");

            }
        }

        [HttpPut("{id}/agencies/add")]
        public async Task<IActionResult> AddAgenciesToUserAsync(int id, [FromBody] List<int> agencies)
        {
            try
            {
                await _AgenciesManager.AddAgenciesToUserAsync(id, agencies);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }

        }
        [HttpPut("{id}/agencies/edit")]
        public async Task<IActionResult> EditAgenciesToUserAsync(int id, [FromBody] List<int> agencies)
        {
            try
            {
                await _AgenciesManager.EditAgenciesToUserAsync(id, agencies);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }

        }

        // POST: api/Users
        [HttpPost("", Name = "AddUser")]
        public async Task<IActionResult> AddUser([FromBody] UserModel user)
        {
            try
            {
                UserRequestDTO objRequest = new UserRequestDTO()
                {

                    bio = user.bio,
                    birthdate = user.birthdate,
                    categoryid = user.categoryid,
                    birthplace = user.birthplace,
                    countryid = user.countryid,
                    lastname = user.lastname,
                    social = user.social,
                    eyes = user.eyes,
                    firstname = user.firstname,
                    heightcm = user.heightcm,
                    weight = user.weight,
                    skin=user.skin,
                    chestcm =user.chestcm,
                    chestinch=user.chestinch,
                    waistcm =user.waistcm,
                    waistinch=user.waistinch,
                    hipscm =user.hipscm,
                    hipsinch=user.hipsinch,
                    hair=user.hair,
                    shoeus=user.shoeus,
                    shoeeu =user.shoeeu
                    };

                int idUser = await _UsersManager.AddUserAsync(objRequest);
                return Ok(idUser);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error has occured");

            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}/login")]
        public async Task<IActionResult> Login(int id, [FromBody] bool log)
        {
            try
            {
                await _UsersManager.loginAsync(id, log);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(500, "An error has occured");

            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditUserAsync(int id, [FromBody] UserModel user)
        {
            try
            {
                UserRequestDTO objRequest = new UserRequestDTO()
                {

                    bio = user.bio,
                    birthdate = user.birthdate,
                    categoryid = user.categoryid,
                    birthplace = user.birthplace,
                    countryid = user.countryid,
                    lastname = user.lastname,
                    social = user.social,
                    eyes = user.eyes,
                    firstname = user.firstname,
                    heightcm = user.heightcm,
                    weight = user.weight
                };

                await _UsersManager.EditUserAsync(id, objRequest);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(500, "An error has occured");

            }
        }




        [HttpPut("{id}/images")]
        public async Task<IActionResult> PutAsync(int id, List<IFormFile> files)
        {
            try
            {
                foreach (IFormFile ufile in files)
                {
                    if (ufile != null && ufile.Length > 0)
                    {
                        var fileName = Path.GetFileName(ufile.FileName);
                        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Pictures\" + id)); // your code goes here
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Pictures\" + id, fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await ufile.CopyToAsync(fileStream);
                        }
                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }



        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            try
            {
                UserResponseDTO objResponse = await _UsersManager.DeleteUserAsync(id);
                return Ok(objResponse);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error has occured");

            }
        }


        [HttpDelete("{id}/image")]
        public IActionResult DeleteImageAsync(int id, [FromQuery] string image)
        {
            try
            {
                _UsersManager.DeleteImage(id, image);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(500, "An error has occured");

            }
        }
    }
}
