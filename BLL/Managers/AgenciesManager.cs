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
    public class AgenciesManager : IAgenciesManager
    {
        private readonly IAgenciesRepository _AgenciesRepository;
        private readonly IHostingEnvironment _HostingEnvironment;
        public AgenciesManager(IAgenciesRepository agenciesRepository, IHostingEnvironment hostingEnvironment)
        {
            _AgenciesRepository = agenciesRepository;
            _HostingEnvironment = hostingEnvironment;
        }

        public async Task<bool> AddAgenciesToUserAsync(int id, List<int> agencies)
        {
            try
            {
                bool agence = await _AgenciesRepository.AddAgenciesToUserAsync(id,agencies);
                return agence;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> AddAgencyAsync(string agency,string link)
        {
            try
            {
                bool agence = await _AgenciesRepository.AddAgencyAsync(agency,link);
                return agence;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task EditAgenciesToUserAsync(int id, List<int> agencies)
        {
            try
            {
                 await _AgenciesRepository.EditAgenciesToUserAsync(id, agencies);
                return ;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<AgencyResponseDTO>> getAgenciesAsync()
        {
            List<AgencyResponseDTO> objResponse = new List<AgencyResponseDTO>();
            try
            {
                objResponse = await _AgenciesRepository.GetAgenciesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return objResponse;
        }
    }
}
