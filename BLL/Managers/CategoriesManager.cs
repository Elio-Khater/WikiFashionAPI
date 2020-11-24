using BLL.Interfaces;
using DAL.Interfaces;
using DTO.ResponseDTO;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public class CategoriesManager : ICategoriesManager
    {
        private readonly ICategoriesRepository _CategoriesRepository;
        private readonly IHostingEnvironment _HostingEnvironment;

        public CategoriesManager(ICategoriesRepository categoriesRepository, IHostingEnvironment hostingEnvironment)
        {
            _CategoriesRepository = categoriesRepository;
            _HostingEnvironment = hostingEnvironment;
        }

        public async Task<List<CategoryResponseDTO>> GetAdvancedFiltersAsync(int id,int agency, string eyes)
        {
            List<CategoryResponseDTO> objResponse = new List<CategoryResponseDTO>();
            try
            {
                objResponse = await _CategoriesRepository.GetAdvancedFiltersAsync(id,agency,eyes);

            }
            catch (System.Exception)
            {

                throw;
            }
            return objResponse;
        }

        public async Task<List<CategoryResponseDTO>> GetListOfCategoriesAsync()
        {
            List<CategoryResponseDTO> objResponse = new List<CategoryResponseDTO>();
            try
            {
                objResponse = await _CategoriesRepository.GetListOfCategoriesAsync();

            }
            catch (System.Exception)
            {

                throw;
            }
            return objResponse;
        }

        public async Task<List<UserResponseDTO>> GetUserByCategoryAsync(int id, List<string> filterArr,int section,string eyes, int agency)
        {
            List<UserResponseDTO> objResponse = new List<UserResponseDTO>();

            try
            {

                objResponse = await _CategoriesRepository.GetUserByCategoryAsync(id,eyes,agency);

                objResponse.Select(u =>
                {
                    var path = Path.Combine(_HostingEnvironment.WebRootPath, "Pictures", u.id.ToString());
                    if (Directory.Exists(path))
                    {
                        string[] fileEntries = Directory.GetFiles(path);
                        u.image = new List<string>();
                        foreach (string fileName in fileEntries)
                        {
                            u.image.Add("Pictures/" + u.id + "/" + Path.GetFileName(fileName));
                        }
                    }
                    else
                    {
                        u.image = new List<string>();
                    }
                    return u;
                }).ToList();
   

                objResponse.Select(u =>
                {
                    if (u.social < 1)
                    {
                        u.socialCount = (u.social * 1000).ToString();
                    }
                    else if (u.social < 1000)
                    {
                        u.socialCount = u.social + "K";
                    }
                    else if (u.social >= 1000)
                    {
                        u.socialCount = (u.social / 1000) + "M";
                    }
                    return u;
                }).ToList();

                if (filterArr.Count > 0)
                {
                    if (filterArr.Contains("MostInstagramFollowers"))
                    {
                        objResponse = objResponse.OrderByDescending(x => x.social).Take(4).ToList();
                    }

                }

                if(section == 1)
                {
                    objResponse = objResponse.OrderByDescending(x => x.social).Take(2).ToList();
                }
                else if(section == 2 )
                {
                    objResponse = objResponse.OrderBy(x => x.social).Take(2).ToList();
                }

                objResponse = objResponse.OrderBy(x => x.firstname).ThenBy(x => x.lastname).ToList();

            }
            catch (System.Exception ex)
            {

                throw;
            }
            return objResponse;
        }
    }
}
