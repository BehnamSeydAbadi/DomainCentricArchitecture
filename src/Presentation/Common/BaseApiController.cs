using Microsoft.AspNetCore.Mvc;

namespace Presentation.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
