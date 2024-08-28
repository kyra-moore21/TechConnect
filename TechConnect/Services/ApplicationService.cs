using Microsoft.EntityFrameworkCore;
using TechConnect.Interfaces;
using TechConnect.Models.Context;
using TechConnect.Models.DTOs;
using TechConnect.Models.Entities;
namespace TechConnect.Services
  
{
    public class ApplicationService : IApplication
    {
        private readonly TechconnectdbContext _context;

        public ApplicationService(TechconnectdbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationDetailDTO>> GetApplicationsAsync()
        {
            var apps = await _context.Applications
                .Select(a => new ApplicationDetailDTO
                {
                    Id = a.Id,
                    Message = a.Message,
                    Status = a.Status,
                    User = new UserDetailDTO
                    {
                        Id = a.User.Id,
                        Email = a.User.Email,
                        FullName = a.User.Email,

                    },
                })
                .ToListAsync();
            return apps;
        }
        public async Task<ApplicationDetailDTO> GetApplicationByIdAsync(int id)
        {
            var app = await _context.Applications
                .Where(u => u.Id == id).FirstOrDefaultAsync();

            ApplicationDetailDTO appDTO = new ApplicationDetailDTO
            {
                Id = app.Id,
                Message = app.Message,
                Status = app.Status,
            };
            return appDTO;
        }
        public async Task<ApplicationCreateDTO> CreateApplicationAsync(ApplicationCreateDTO createApplicationDTO)
        {
            var application = new Application
            {
                Message = createApplicationDTO.Message,
                Status = createApplicationDTO.Status,
            };
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();
            return new ApplicationCreateDTO     
            {
               
                Message = application.Message,
                Status = application.Status,
              
            };
        }
        public async Task<ApplicationDetailDTO> UpdateApplicationAsync(int id, ApplicationDetailDTO applicationDTO)
        {
            Application u = await _context.Applications.FindAsync(id);
            if(u == null)
            {
                return null;
            }
            u.Message = applicationDTO.Message;
            u.Status = applicationDTO.Status;
            await _context.SaveChangesAsync();


            return new ApplicationDetailDTO
            {
                Id =  u.Id,
                Message = u.Message,
                Status = u.Status,

            };

        }

        public async Task<bool> DeleteApplicationAsync(int id)
        {
            var app = await _context.Applications.FindAsync(id);
            if(app != null)
            {
                _context.Applications.Remove(app);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
