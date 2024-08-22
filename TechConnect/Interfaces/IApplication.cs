using TechConnect.Models.DTOs;

namespace TechConnect.Interfaces
{
    public interface IApplication
    {
        Task<List<ApplicationDTO>> GetApplicationsAsync();
        Task<ApplicationDTO> GetApplicationByIdAsync(int id);
        Task<ApplicationDTO> CreateApplicationAsync(CreateApplicationDTO createApplicationDTO);
        Task<ApplicationDTO> UpdateApplicationAsync(int id, ApplicationDTO applicationDTO);
        Task<bool> DeleteApplicationAsync(int id);
    }
}
