using TechConnect.Models.DTOs;

namespace TechConnect.Interfaces
{
    public interface IApplication
    {
        Task<List<ApplicationDetailDTO>> GetApplicationsAsync();
        Task<ApplicationDetailDTO> GetApplicationByIdAsync(int id);
        Task<ApplicationCreateDTO> CreateApplicationAsync(ApplicationCreateDTO createApplicationDTO);
        Task<ApplicationDetailDTO> UpdateApplicationAsync(int id, ApplicationDetailDTO applicationDTO);
        Task<bool> DeleteApplicationAsync(int id);
    }
}
