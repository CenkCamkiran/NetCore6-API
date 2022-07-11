using MiddlewareLayer;
using Configurations;

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
    //These config changes depending the environment (DEV or PROD etc.)
    //var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true);
    app.UseSwagger();
    app.UseSwaggerUI();
}

ConfigurationManager configuration = builder.Configuration;
configuration.GetSection(ApplicationSettingsModel.RootOption).Bind(ApplicationSettingsModel.ExternalTools);

//app.UsePathBase(new PathString("/rest/api/v1")); //Value must start with '/' //This is not working

app.Use(async (context, next) =>
{
    context.Request.EnableBuffering();

    context.Request.Headers.Date = DateTime.Now.ToString();
	//This line of code can be used to seeking or reading stream second or multiple times.
	//Old C# code is EnableRewind(). This code does the same job of EnableBuffering. EnableBuffering => ASP.NET Core 2.1
	//Ideally do this early in the middleware before anything needs to read the body

	try
	{
		await next();
	}
	catch (Exception exception)
	{
		Console.WriteLine(exception.Message.ToString());
	}
});

//app.UseErrorHandlerMiddleware(); enters ErrorMiddleware but not LoggingMiddleware. Why?

app.UseResponseReadableStreamMiddleware();

app.UseLoggingMiddleware(); //If exception will happen, it wont enter ErrorHandlerMiddleware.

app.UseErrorHandlerMiddleware();

//app.UseWhen(context => context.Request.Path.StartsWithSegments("/rest/api/v1/user"), appBuilder =>  // The path must be started with '/'
//{
//	appBuilder.UseRequestParamsValidationMiddleware();
//});

app.UseWhen(context => context.Request.Path.StartsWithSegments("/rest/api/v1/main"), appBuilder =>  // The path must be started with '/'
{
    appBuilder.UseTokenControlMiddleware();
});

app.UseWhen(context => context.Request.Path.StartsWithSegments("/rest/api/v1/main"), appBuilder =>  // The path must be started with '/'
{
    appBuilder.UseSessionControlMiddleware();
    //appBuilder.UseMiddleware<AuthenticationMiddleware>(); //Same thing //
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/********************************************************
 * 
 * 
 * 
 * 
 ********************************************************/

//Below code does not open browser for some reason? 
//But app.Run(); can launch the browser
//if (app.Environment.IsDevelopment())
//{
//    app.Run("http://localhost:7080");
//}
//else
//{
//    app.Run();
//}

// appsettings.{Environment}.json
//var configurationBuilder = new ConfigurationBuilder();
//configurationBuilder.AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true);
//configurationBuilder.AddUserSecrets(typeof(Program).GetTypeInfo().Assembly, optional: false);
//IConfigurationRoot Configuration = configurationBuilder.Build();

//app.Use(async (context, next) =>
//{
//    // Do work that can write to the Response.
//    await next();
//    // Do logging or other work that doesn't write to the Response.

//    //Or both of them?
//});

//var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true);

//app.MapWhen(context => context.Request.Path.StartsWithSegments("/WeatherForecast", StringComparison.OrdinalIgnoreCase), appBuilder =>
//{
//    appBuilder.UseKeycloakAdminMiddleware();
//});

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