using Microsoft.AspNetCore.Mvc;

namespace Presentation.Common
{
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
