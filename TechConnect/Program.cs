using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using TechConnect.Interfaces;
using TechConnect.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Initalize Firebase
var serviceAccountKeyPath = builder.Configuration["Firebase:ServiceAccountKeyPath"];
FirebaseApp.Create(new AppOptions
{
    Credential = GoogleCredential.FromFile(serviceAccountKeyPath)
});

// Register FirebaseAuthService
builder.Services.AddScoped<IFirebaseAuthService, FirebaseAuthService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
