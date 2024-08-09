using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechConnect.Models.Context;

namespace TechConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        public TechconnectdbContext dbContext = new TechconnectdbContext();
    }
}
