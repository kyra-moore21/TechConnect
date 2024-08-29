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

        //TBD get applications by post so you can view applications for  post
        //get applications by userid so you can view your own
        //pagination for applications
        public async Task<List<ApplicationDetailDTO>> GetApplicationsAsync()
        {
            var apps = await _context.Applications
                .Select(a => new ApplicationDetailDTO
                {
                    Id = a.Id,
                    Message = a.Message,
                    Status = a.Status,
                    AppDate = a.AppDate,
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
                AppDate = app.AppDate,
                User = new UserDetailDTO
                {
                    Id = app.User.Id,
                    Email = app.User.Email,
                    FullName = app.User.Email,

                }
            };
            return appDTO;
        }
        public async Task<ApplicationCreateDTO> CreateApplicationAsync(ApplicationCreateDTO createApplicationDTO)
        {
            var application = new Application
            {

                UserId = createApplicationDTO.UserId,
                PostId = createApplicationDTO.PostId,
                Message = createApplicationDTO.Message,
                Status = createApplicationDTO.Status,
            };
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();
            return new ApplicationCreateDTO
            {
                UserId = application.UserId,
                PostId = application.PostId,
                Message = application.Message,
                Status = application.Status,

            };
        }
        public async Task<ApplicationDetailDTO> UpdateApplicationAsync(int id, ApplicationDetailDTO applicationDTO)
        {
            Application u = await _context.Applications.FindAsync(id);
            if (u == null)
            {
                return null;
            }
            u.Message = applicationDTO.Message;
            u.Status = applicationDTO.Status;
            await _context.SaveChangesAsync();


            return new ApplicationDetailDTO
            {
                Id = u.Id,
                Message = u.Message,
                Status = u.Status,
                AppDate = u.AppDate,
                User = new UserDetailDTO { Id = u.User.Id, Email = u.User.Email, FullName = u.User.Email }
            };

        }

        public async Task<bool> DeleteApplicationAsync(int id)
        {
            var app = await _context.Applications.FindAsync(id);
            if (app != null)
            {
                _context.Applications.Remove(app);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
