using Microsoft.AspNetCore.Mvc;

    namespace WebStorage.Api.Controllers;
    [Route("api/[controller]")]
    [ApiController]
    public class storageController : ControllerBase
    {
    [HttpPost]
    public IActionResult uploadImage(IFormFile file)
    {
        return Created();
    }
    }

