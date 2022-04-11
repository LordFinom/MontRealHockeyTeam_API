
using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.OpenApi.Models;
using MontrealHockeyTeamAPI.DAL;
using MontrealHockeyTeamAPI.Interfaces;
using MontrealHockeyTeamAPI.Interfaces.implements;
using MontrealHockeyTeamAPI.Models;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// DATA Access DI
builder.Services.AddScoped<ITeamDataAccess, TeamData>();
builder.Services.AddScoped<IPlayerDataAccess, PlayerData>();

builder.Services.AddMvc(option => option.EnableEndpointRouting = false)
    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
//Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "MontRealHockeyTEam API",
        Description = "Web API .NET 6.0 here to manage Montreal canadiens roster",
    });
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

if (!builder.Environment.IsDevelopment())
{
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(5000); // to listen for incoming http connection on port 5000
        options.ListenAnyIP(5001, configure => configure.UseHttps()); // to listen for incoming https connection on port 5001
    });
}


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// global cors policy
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

//app.UseAuthentication();

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();

