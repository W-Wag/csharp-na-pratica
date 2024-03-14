using CloudStorageTest.Application.UseCases.Users.UploadProfilePhoto;
using CloudStorageTest.Domain.Storage;
using CloudStorageTest.Infrastructure.Storage;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Util.Store;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUploadProfilePhotoUseCase, UploadProfilePhotoUseCase>();
builder.Services.AddScoped<IStorageService>(options =>
{
    // Put the ClientId and ClientSecret in appsettings.Development.json
    var clientId = builder.Configuration.GetValue<string>("CloudStorage:ClientId");
    var clientSecret = builder.Configuration.GetValue<string>("CloudStorage:ClientSecret");
    var apiCodeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
    {
        ClientSecrets = new Google.Apis.Auth.OAuth2.ClientSecrets
        {
            ClientId = clientId,
            ClientSecret = clientSecret
        },
        Scopes = [Google.Apis.Drive.v3.DriveService.Scope.Drive],
        DataStore = new FileDataStore("Name of application in Google Console")
    });
    return new GoogleDriveStorageService(apiCodeFlow);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
