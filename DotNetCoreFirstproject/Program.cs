using DotNetCoreFirstproject.Middleware;

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
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<KeycloakAdminMiddleware>();

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

app.UseWhen(context => context.Request.Path.StartsWithSegments("/WeatherForecast", StringComparison.OrdinalIgnoreCase), appBuilder => MiddlewareCenk(appBuilder));

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello from non-Map delegate. <p>");
//});


//app.Map("/WeatherForecast", Middleware1);

//app.Map("/UserSignup", Middleware2);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


static void MiddlewareCenk(IApplicationBuilder app)
{
    //app.Run(async context =>
    //{
    //    context.Response.StatusCode = 201;
    //    await context.Response.WriteAsync("Hello Middleware 1");
    //});

    app.Use(async (context, next) =>
    {
        context.Response.StatusCode = 201;
        await next.Invoke();
    });
}

