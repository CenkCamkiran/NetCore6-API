using DotNetCoreFirstproject.Configuration;
using DotNetCoreFirstproject.Middleware;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //DEV veya PROD ortamýna göre aþaðýdaki string ifade deðiþecek.
    //var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true);
    app.UseSwagger();
    app.UseSwaggerUI();
}

// appsettings.{Environment}.json
//var configurationBuilder = new ConfigurationBuilder();
//configurationBuilder.AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true);
//configurationBuilder.AddUserSecrets(typeof(Program).GetTypeInfo().Assembly, optional: false);
//IConfigurationRoot Configuration = configurationBuilder.Build();

ConfigurationManager configuration = builder.Configuration;
configuration.GetSection(ProjectSettings.RootOption).Bind(ProjectSettings.ExternalTools);



//var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true);

//app.MapWhen(context => context.Request.Path.StartsWithSegments("/WeatherForecast", StringComparison.OrdinalIgnoreCase), appBuilder =>
//{
//    appBuilder.UseKeycloakAdminMiddleware();
//});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//static void MiddlewareCenk(IApplicationBuilder app)
//{
//    //app.Run(async context =>
//    //{
//    //    context.Response.StatusCode = 201;
//    //    await context.Response.WriteAsync("Hello Middleware 1");
//    //});

//    app.Use(async (context, next) =>
//    {
//        context.Response.StatusCode = 201;
//        await next.Invoke();
//    });
//}

/* Tutorial of Middleware 
 * 
 * 
 * //app.UseMiddleware<KeycloakAdminMiddleware>();

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello Middleware 1");
//});

//app.Use(async (context, next) =>
//{
//    // Do work that can write to the Response.
//    //context.Response.StatusCode = 202;
//    await next.Invoke();
//    // Do logging or other work that doesn't write to the Response.
//});

//app.MapWhen(context => context.Request.Path.StartsWithSegments("/WeatherForecast", StringComparison.OrdinalIgnoreCase), appBuilder =>
//{
//    appBuilder.UseKeycloakAdminMiddleware();
//});

//app.MapWhen(context => context.Request.Path.StartsWithSegments("/WeatherForecast", StringComparison.OrdinalIgnoreCase), appBuilder => MiddlewareCenk(appBuilder));
 * 
 * 
 * //app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello from non-Map delegate. <p>");
//});


//app.Map("/WeatherForecast", Middleware1);

//app.Map("/UserSignup", Middleware2);
 */



//static void MiddlewareCenk(IApplicationBuilder app)
//{
//    //app.Run(async context =>
//    //{
//    //    context.Response.StatusCode = 201;
//    //    await context.Response.WriteAsync("Hello Middleware 1");
//    //});

//    app.Use(async (context, next) =>
//    {
//        context.Response.StatusCode = 201;
//        await next.Invoke();
//    });
//}