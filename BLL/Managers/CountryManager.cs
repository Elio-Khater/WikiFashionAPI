using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Repositories;
using DTO.ResponseDTO;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public class CountryManager : ICountryManager
    {
        private readonly ICountryRepository _CountryRepository;
        private readonly IHostingEnvironment _HostingEnvironment;
        public CountryManager(ICountryRepository countryRepository, IHostingEnvironment hostingEnvironment)
        {
            _CountryRepository = countryRepository;
            _HostingEnvironment = hostingEnvironment;
        }
       

        async Task<List<CountryResponseDTO>> ICountryManager.getCountriesAsync()
        {
            List<CountryResponseDTO> objResponse = new List<CountryResponseDTO>();
            try
            {
                objResponse = await _CountryRepository.GetCountriesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return objResponse;
        }
    }
}
