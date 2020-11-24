using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DTO.ResponseDTO;

namespace BLL.Interfaces
{
    public interface IAgenciesManager
    {
        Task<List<AgencyResponseDTO>> getAgenciesAsync();
        Task<bool> AddAgencyAsync(string agency,string link);
        Task<bool> AddAgenciesToUserAsync(int id, List<int> agencies);
        Task EditAgenciesToUserAsync(int id, List<int> agencies);
    }
}
