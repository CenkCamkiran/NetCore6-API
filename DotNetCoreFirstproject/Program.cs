using Configurations;
using DataAccessLayer.ElasticSearch.Infrastructure;
using DataAccessLayer.ElasticSearch.Interfaces;
using DataAccessLayer.ElasticSearch.Repository;
using DataAccessLayer.MongoDB.Interfaces;
using DataAccessLayer.MongoDB.Repository;
using DataAccessLayer.MSSQL.Interfaces;
using DataAccessLayer.MSSQL.Repository;
using DataAccessLayer.Redis.Infrastructure;
using DataAccessLayer.RabbitMQ.Infrastructure;
using DataAccessLayer.RabbitMQ.Interfaces;
using DataAccessLayer.RabbitMQ.Repository;
using DataAccessLayer.Redis.Interfaces;
using DataAccessLayer.Redis.Repository;
using Elasticsearch.Net;
using Microsoft.Extensions.DependencyInjection;
using MiddlewareLayer;
using MongoDB.Driver;
using Nest;
using RabbitMQ.Client;
using ServiceLayer;
using ServiceLayer.Interfaces;
using StackExchange.Redis;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using IConnection = RabbitMQ.Client.IConnection;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
configuration.GetSection(ApplicationSettingsModel.RootOption).Bind(ApplicationSettingsModel.ExternalTools);

// ***************************************************************************************************
// Add services to the container.

//AppConfiguration appConfiguration = new AppConfiguration();
//Dictionary<string, string> redisConfig = appConfiguration.GetRedisConfig();
//Dictionary<string, string> mongodbConfig = appConfiguration.GetMongoDBConfig();
//Dictionary<string, string> elasticConfig = appConfiguration.GetElasticSearchConfig();
//Dictionary<string, string> mssqlConfig = appConfiguration.GetMSSQLConfig();
//Dictionary<string, string> rabbitConfig = appConfiguration.GetRabbitMQConfig();


//var options = ConfigurationOptions.Parse(redisConfig["RedisHost"]);
//options.Password = redisConfig["Password"];
//var redisConnection = ConnectionMultiplexer.Connect(options);
//builder.Services.AddSingleton<IConnectionMultiplexer>(redisConnection);
//builder.Services.AddScoped<IPostsCacheRepository, PostsCacheRepository>();
//builder.Services.AddScoped<IPostsRepository, PostsRepository>();
//builder.Services.AddScoped<IPostsService, PostsService>();
//builder.Services.AddScoped<ICustomersService, CustomersService>();
//builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
//builder.Services.AddScoped<IKeycloakService, KeycloakService>();
//builder.Services.AddScoped<IPingService, PingService>();
//builder.Services.AddScoped<IMovieService, MoviesService>();
//builder.Services.AddScoped<IMoviesRepository, MoviesRepository>();
//builder.Services.AddScoped<IMoviesCacheRepository, MoviesCacheRepository>();
//builder.Services.AddScoped<IElasticSearchCommand, ElasticSearchCommand>();
//builder.Services.AddScoped<IControllerLogRepository, ControllerLogRepository>();
//builder.Services.AddScoped<ILoggingService, LoggingService>();
//builder.Services.AddScoped<ICustomerAccountsService, CustomerAccountsService>();
//builder.Services.AddScoped<ICustomerAccountsRepository, CustomerAccountsRepository>();
//builder.Services.AddScoped<ICustomerAccountTransactionsService, CustomerAccountTransactionsService>();
//builder.Services.AddScoped<ICustomerAccountTransactionsRepository, CustomerAccountTransactionsRepository>();
//builder.Services.AddScoped<ICustomerCacheRepository, CustomerCacheRepository>();
//builder.Services.AddScoped<IPersonService, PersonService>();
//builder.Services.AddScoped<IPersonRepository, PersonRepository>();
//builder.Services.AddScoped<IRedisCommand, RedisCommand>();
//builder.Services.AddScoped<ITestQueueService, TestQueueService>();
//builder.Services.AddScoped<ITestQueueRepository, TestQueueRepository>();
//builder.Services.AddScoped<IRabbitMQCommand, RabbitMQCommand>();
builder.Services.AddScoped<ITesting, TestingService>();
//builder.Services.AddHealthChecks();
builder.Services.AddControllers();


//MongoClient mongoClient = new MongoClient(mongodbConfig["MongoDBConnectionString"]);
//builder.Services.AddSingleton<IMongoClient>(mongoClient);


//ConnectionSettings? connection = new ConnectionSettings(new Uri(elasticConfig["ElasticHost"])).
//   DefaultIndex(elasticConfig["DefaultIndexName"]).
//   ServerCertificateValidationCallback(CertificateValidations.AllowAll).
//   ThrowExceptions(true).
//   PrettyJson().
//   RequestTimeout(TimeSpan.FromSeconds(300)).
//   BasicAuthentication(elasticConfig["ElasticRootUsername"], elasticConfig["ElasticRootPassword"]); //.ApiKeyAuthentication("<id>", "<api key>"); 

//ElasticClient? elasticClient = new ElasticClient(connection);
//builder.Services.AddSingleton<IElasticClient>(elasticClient);

//SqlConnectionStringBuilder mssqlConnBuilder = new SqlConnectionStringBuilder();
//mssqlConnBuilder.DataSource = mssqlConfig["Host"];
//mssqlConnBuilder.UserID = mssqlConfig["Username"];
//mssqlConnBuilder.Password = mssqlConfig["MSSQLPassword"];
//mssqlConnBuilder.InitialCatalog = mssqlConfig["DBName"];
//SqlConnection sqlConnection = new SqlConnection(mssqlConnBuilder.ConnectionString);
//builder.Services.AddSingleton<IDbConnection>(sqlConnection);

//var connectionFactory = new ConnectionFactory
//{
//	HostName = rabbitConfig["RabbitMQHost"],
//	Port = Convert.ToInt32(rabbitConfig["RabbitMQPort"]),
//	UserName = rabbitConfig["RabbitMQUsername"],
//	Password = rabbitConfig["RabbitMQPassword"]
//};

//var rabbitConnection = connectionFactory.CreateConnection();
//builder.Services.AddSingleton<IConnection>(rabbitConnection);

// ***************************************************************************************************

// ********************************* For Swagger *********************************
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// ********************************* For Swagger *********************************

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	//These config changes depending the environment (DEV or PROD etc.)
	//var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true);
	app.UseSwagger();
	app.UseSwaggerUI();
}

//app.UsePathBase(new PathString("/rest/api/v1")); //Value must start with '/' //This is not working

/* ************************************************************************************ */
//app.Use(async (context, next) =>
//{
//	context.Request.EnableBuffering();

//	context.Request.Headers.Date = DateTime.Now.ToString();
//	//This line of code can be used to seeking or reading stream second or multiple times.
//	//Old C# code is EnableRewind(). This code does the same job of EnableBuffering. EnableBuffering => ASP.NET Core 2.1
//	//Ideally do this early in the middleware before anything needs to read the body

//	try
//	{
//		await next();
//	}
//	catch (Exception exception)
//	{
//		Console.WriteLine(exception.Message.ToString());
//	}
//});
/* ************************************************************************************ */

//app.UseErrorHandlerMiddleware(); enters ErrorMiddleware but not LoggingMiddleware. Why?

/* ************************************************************************************ */

app.UseWhen(context => context.Request.Path.StartsWithSegments("/rest/api/v1"), appBuilder =>  // The path must be started with '/'
{
	appBuilder.UseTestingMiddleware();
});

//app.UseResponseReadableStreamMiddleware();

//app.UseLoggingMiddleware(); //If exception will happen, it wont enter ErrorHandlerMiddleware.

//app.UseErrorHandlerMiddleware();

//app.UseWhen(context => context.Request.Path.StartsWithSegments("/rest/api/v1/main"), appBuilder =>  // The path must be started with '/'
//{
//	appBuilder.UseTokenControlMiddleware();
//});

//app.UseWhen(context => context.Request.Path.StartsWithSegments("/rest/api/v1/main"), appBuilder =>  // The path must be started with '/'
//{
//	appBuilder.UseSessionControlMiddleware();
//	//appBuilder.UseMiddleware<AuthenticationMiddleware>(); //Same thing //
//});

/* ************************************************************************************ */

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//services.AddCors(options =>
//{
//options.AddPolicy("ClientPermission", policy =>
//{
//	policy.AllowAnyHeader()
//		  .AllowAnyMethod()
//		  .WithOrigins("http://localhost:3000")
//		  .AllowCredentials();
//});

/********************************************************
 * 
 * Codes for test purposes
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