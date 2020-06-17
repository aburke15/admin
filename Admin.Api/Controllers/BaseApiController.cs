using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Admin.Api.Controllers
{
    [ApiController]
    [Route("admin/api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        
    }
}