using Microsoft.AspNetCore.Mvc;

namespace SkyAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TesteController : ControllerBase
{
    // Este método vai responder quando o frontend chamar a API
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("A API da SkyMedia está viva e o CORS está a funcionar perfeitamente!");
    }
}