using CloudStorageTest.Application.UseCases.Users.UploadProfilePhoto;
using Microsoft.AspNetCore.Mvc;

namespace WebStorage.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StorageController : ControllerBase
{
    [HttpPost]
    public IActionResult uploadImage([FromServices] IUploadProfilePhotoUseCase useCase, IFormFile file)
    {
        useCase.Execute(file);
        return Created();
    }
}

