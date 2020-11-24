using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.ResponseDTO;

namespace DAL.Repositories
{
    public interface ICountryRepository
    {
        Task<List<CountryResponseDTO>> GetCountriesAsync();
    }
}