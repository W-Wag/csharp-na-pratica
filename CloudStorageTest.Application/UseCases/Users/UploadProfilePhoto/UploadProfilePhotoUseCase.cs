using CloudStorageTest.Domain.Entities;
using CloudStorageTest.Domain.Storage;
using FileTypeChecker;
using FileTypeChecker.Extensions;
using FileTypeChecker.Types;
using Microsoft.AspNetCore.Http;

namespace CloudStorageTest.Application.UseCases.Users.UploadProfilePhoto;
public class UploadProfilePhotoUseCase : IUploadProfilePhotoUseCase
{
    env
    private readonly IStorageService _storageService;
    public UploadProfilePhotoUseCase(IStorageService storageService)
    {
        _storageService = storageService;
    }
    public void Execute(IFormFile file)
    {
        var fileStream = file.OpenReadStream();
        var isImage = fileStream.Is<JointPhotographicExpertsGroup>();
        if (isImage == false)
            throw new Exception("The File is not an image.");

        var user = GetFromDataBase();
        _storageService.Upload(file, user);
    }

    private User GetFromDataBase()
    {
        return new User
        {
            Id = 1,
            Name = "Your name",
            Email = "Your email",
            RefreshToken = "Get From https://developers.google.com/oauthplayground",
            AccessToken = "Get From https://developers.google.com/oauthplayground"

        }
}
