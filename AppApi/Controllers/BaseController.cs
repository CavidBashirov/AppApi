using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
    }
}
