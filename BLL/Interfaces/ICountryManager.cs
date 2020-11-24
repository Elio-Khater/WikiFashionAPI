using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DTO.ResponseDTO;

namespace BLL.Interfaces
{
    public interface ICountryManager
    {
         Task<List<CountryResponseDTO>> getCountriesAsync();

       
    }
}
