![](https://wallpapercave.com/wp/wp7718117.jpg)

# API Project with .NET Core 6

## Features

- Developed via Npgsql and NewtonsoftJson Library
- Uses PostgreSQL Database
- Easy to deploy
- Can run on any platform (Mac, Linux ve Windows)
- It is a Console Application. Simple!

## Installation

#### ElasticSearch (Write Installation and Configurations)

```bash
$ export POSTGRE_PWD="..."
$ export POSTGRE_USER="..."
$ export POSTGRE_DB="..."
$ echo $POSTGRE_PWD - $POSTGRE_USER - $POSTGRE_DB //check the contents of environment variables
$ docker-compose up -d //This command must be executed in the same directory of docker-compose file
```

#### Kibana (Write Installation and Configurations)

```bash
$ export POSTGRE_PWD="..."
$ export POSTGRE_USER="..."
$ export POSTGRE_DB="..."
$ echo $POSTGRE_PWD - $POSTGRE_USER - $POSTGRE_DB //check the contents of environment variables
$ docker-compose up -d //This command must be executed in the same directory of docker-compose file
```

#### MongoDB (Write Installation and Configurations)

```bash
$ export POSTGRE_PWD="..."
$ export POSTGRE_USER="..."
$ export POSTGRE_DB="..."
$ echo $POSTGRE_PWD - $POSTGRE_USER - $POSTGRE_DB //check the contents of environment variables
$ docker-compose up -d //This command must be executed in the same directory of docker-compose file
```

#### Keycloak (Write Installation and Configurations. For example keycloak global settings json file)

```bash
$ export POSTGRE_PWD="..."
$ export POSTGRE_USER="..."
$ export POSTGRE_DB="..."
$ echo $POSTGRE_PWD - $POSTGRE_USER - $POSTGRE_DB //check the contents of environment variables
$ docker-compose up -d //This command must be executed in the same directory of docker-compose file
```

#### RabbitMQ (Write Installation and Configurations)

```bash
$ export POSTGRE_PWD="..."
$ export POSTGRE_USER="..."
$ export POSTGRE_DB="..."
$ echo $POSTGRE_PWD - $POSTGRE_USER - $POSTGRE_DB //check the contents of environment variables
$ docker-compose up -d //This command must be executed in the same directory of docker-compose file
```

#### Install project with Docker Container (Dockerfile)

```bash
$ git clone https://github.com/CenkCamkiran/OpenWeather-DotNet-Docker-Project.git
$ docker build -t weatherapp .
$ docker run -d --name openweatherapp -t weatherapp --restart on-failure
$ docker logs -t --since 1h //Watch the logs of container
```

(Will be edited in the future. Delet dlls etc. only necessary files)

## Structure

```
|   .dockerignore
|   .gitignore
|   cengo.txt
|   cenk.doc
|   NetCore6API.sln
|   README.md
|
+---.vs
|   +---DotNetCoreFirstproject
|   |   \---FileContentIndex
|   |           3267758e-b021-4ab2-b5ee-683780c35b5f.vsidx
|   |           61fd49ea-4b3a-401f-936c-9222ef382daa.vsidx
|   |           7a067646-098b-4eaa-947c-61632915e858.vsidx
|   |           ffd693a8-e768-450b-85dd-cb7564003e73.vsidx
|   |           read.lock
|   |
|   +---NetCore6API
|   |   \---v17
|   \---ProjectEvaluation
|           dotnetcorefirstproject.metadata.v2
|           dotnetcorefirstproject.projects.v2
|
+---APILayer
|   |   APILayer.csproj
|   |
|   +---bin
|   |   \---Debug
|   |       \---net6.0
|   |               APILayer.deps.json
|   |               APILayer.dll
|   |               APILayer.pdb
|   |               Configurations.dll
|   |               Configurations.pdb
|   |               DataAccessLayer.dll
|   |               DataAccessLayer.pdb
|   |               Helpers.dll
|   |               Helpers.pdb
|   |               Models.dll
|   |               Models.pdb
|   |               ServiceLayer.dll
|   |               ServiceLayer.pdb
|   |
|   +---Controllers
|   |   +---Customers
|   |   |       CustomersController.cs
|   |   |
|   |   +---Health
|   |   |       ApiHealthController.cs
|   |   |
|   |   +---Posts
|   |   |       PostsController.cs
|   |   |
|   |   \---User
|   |           LoginController.cs
|   |           LogoutController.cs
|   |           SignupController.cs
|   |
|   \---obj
|       |   APILayer.csproj.nuget.dgspec.json
|       |   APILayer.csproj.nuget.g.props
|       |   APILayer.csproj.nuget.g.targets
|       |   project.assets.json
|       |   project.nuget.cache
|       |
|       \---Debug
|           \---net6.0
|               |   .NETCoreApp,Version=v6.0.AssemblyAttributes.cs
|               |   APILayer.AssemblyInfo.cs
|               |   APILayer.AssemblyInfoInputs.cache
|               |   APILayer.assets.cache
|               |   APILayer.csproj.AssemblyReference.cache
|               |   APILayer.csproj.BuildWithSkipAnalyzers
|               |   APILayer.csproj.CopyComplete
|               |   APILayer.csproj.CoreCompileInputs.cache
|               |   APILayer.csproj.FileListAbsolute.txt
|               |   APILayer.dll
|               |   APILayer.GeneratedMSBuildEditorConfig.editorconfig
|               |   APILayer.GlobalUsings.g.cs
|               |   APILayer.pdb
|               |
|               +---ref
|               |       APILayer.dll
|               |
|               \---refint
|                       APILayer.dll
|
+---BusinessLayer
|   |   CustomersService.cs
|   |   KeycloakService.cs
|   |   LoggingService.cs
|   |   PingService.cs
|   |   PostsService.cs
|   |   ServiceLayer.csproj
|   |
|   +---bin
|   |   \---Debug
|   |       \---net6.0
|   |               BusinessLayer.deps.json
|   |               BusinessLayer.dll
|   |               BusinessLayer.pdb
|   |               Configurations.dll
|   |               Configurations.pdb
|   |               DataAccessLayer.dll
|   |               DataAccessLayer.pdb
|   |               Helpers.dll
|   |               Helpers.pdb
|   |               Models.dll
|   |               Models.pdb
|   |               ServiceLayer.deps.json
|   |               ServiceLayer.dll
|   |               ServiceLayer.pdb
|   |
|   +---Interfaces
|   |       ICachingService.cs
|   |       ICustomersService.cs
|   |       IKeycloakService.cs
|   |       ILoggingService.cs
|   |       IPingService.cs
|   |       IPostsService.cs
|   |
|   \---obj
|       |   BusinessLayer.csproj.nuget.dgspec.json
|       |   BusinessLayer.csproj.nuget.g.props
|       |   BusinessLayer.csproj.nuget.g.targets
|       |   project.assets.json
|       |   project.nuget.cache
|       |   ServiceLayer.csproj.nuget.dgspec.json
|       |   ServiceLayer.csproj.nuget.g.props
|       |   ServiceLayer.csproj.nuget.g.targets
|       |
|       \---Debug
|           \---net6.0
|               |   .NETCoreApp,Version=v6.0.AssemblyAttributes.cs
|               |   BusinessLayer.AssemblyInfo.cs
|               |   BusinessLayer.AssemblyInfoInputs.cache
|               |   BusinessLayer.assets.cache
|               |   BusinessLayer.csproj.AssemblyReference.cache
|               |   BusinessLayer.csproj.BuildWithSkipAnalyzers
|               |   BusinessLayer.csproj.CopyComplete
|               |   BusinessLayer.csproj.CoreCompileInputs.cache
|               |   BusinessLayer.csproj.FileListAbsolute.txt
|               |   BusinessLayer.dll
|               |   BusinessLayer.GeneratedMSBuildEditorConfig.editorconfig
|               |   BusinessLayer.GlobalUsings.g.cs
|               |   BusinessLayer.pdb
|               |   ServiceLayer.AssemblyInfo.cs
|               |   ServiceLayer.AssemblyInfoInputs.cache
|               |   ServiceLayer.assets.cache
|               |   ServiceLayer.csproj.AssemblyReference.cache
|               |   ServiceLayer.csproj.BuildWithSkipAnalyzers
|               |   ServiceLayer.csproj.CopyComplete
|               |   ServiceLayer.csproj.CoreCompileInputs.cache
|               |   ServiceLayer.csproj.FileListAbsolute.txt
|               |   ServiceLayer.dll
|               |   ServiceLayer.GeneratedMSBuildEditorConfig.editorconfig
|               |   ServiceLayer.GlobalUsings.g.cs
|               |   ServiceLayer.pdb
|               |
|               +---ref
|               |       BusinessLayer.dll
|               |       ServiceLayer.dll
|               |
|               \---refint
|                       BusinessLayer.dll
|                       ServiceLayer.dll
|
+---Configurations
|   |   AppConfiguration.cs
|   |   ApplicationOptionsModel.cs
|   |   ApplicationSettingsModel.cs
|   |   Configurations.csproj
|   |
|   +---bin
|   |   \---Debug
|   |       \---net6.0
|   |               Configurations.deps.json
|   |               Configurations.dll
|   |               Configurations.pdb
|   |
|   +---ElasticConfigurations
|   |       ElasticsearchConfigurationModel.cs
|   |
|   +---KeycloakConfigurations
|   |       KeycloakConfigurationModel.cs
|   |
|   +---MongoDBConfigurations
|   |       MongoDBConfigurationModel.cs
|   |
|   +---obj
|   |   |   Configurations.csproj.nuget.dgspec.json
|   |   |   Configurations.csproj.nuget.g.props
|   |   |   Configurations.csproj.nuget.g.targets
|   |   |   project.assets.json
|   |   |   project.nuget.cache
|   |   |
|   |   \---Debug
|   |       \---net6.0
|   |           |   .NETCoreApp,Version=v6.0.AssemblyAttributes.cs
|   |           |   Configurations.AssemblyInfo.cs
|   |           |   Configurations.AssemblyInfoInputs.cache
|   |           |   Configurations.assets.cache
|   |           |   Configurations.csproj.AssemblyReference.cache
|   |           |   Configurations.csproj.BuildWithSkipAnalyzers
|   |           |   Configurations.csproj.CoreCompileInputs.cache
|   |           |   Configurations.csproj.FileListAbsolute.txt
|   |           |   Configurations.dll
|   |           |   Configurations.GeneratedMSBuildEditorConfig.editorconfig
|   |           |   Configurations.GlobalUsings.g.cs
|   |           |   Configurations.pdb
|   |           |
|   |           +---ref
|   |           |       Configurations.dll
|   |           |
|   |           \---refint
|   |                   Configurations.dll
|   |
|   \---RedisConfigurations
|           RedisConfigurationModel.cs
|
+---DataAccessLayer
|   |   DataAccessLayer.csproj
|   |
|   +---bin
|   |   \---Debug
|   |       \---net6.0
|   |               Configurations.dll
|   |               Configurations.pdb
|   |               DataAccessLayer.deps.json
|   |               DataAccessLayer.dll
|   |               DataAccessLayer.pdb
|   |               Helpers.dll
|   |               Helpers.pdb
|   |               Models.dll
|   |               Models.pdb
|   |
|   +---ElasticSearch
|   |   +---Infrastructure
|   |   |       ElasticSearchCommand.cs
|   |   |
|   |   +---Interfaces
|   |   |       IControllerLogRepository.cs
|   |   |       IElasticSearchCommand.cs
|   |   |       IKeycloakLog.cs
|   |   |
|   |   \---Repository
|   |           ControllerLogRepository.cs
|   |
|   +---MongoDB
|   |   +---Infrastructure
|   |   |       MongoDBCommand.cs
|   |   |
|   |   +---Interfaces
|   |   |       ICustomersRepository.cs
|   |   |       IMongoDBCommand.cs
|   |   |       IPostsRepository.cs
|   |   |
|   |   \---Repository
|   |           CustomersRepository.cs
|   |           PostsRepository.cs
|   |
|   +---obj
|   |   |   DataAccessLayer.csproj.nuget.dgspec.json
|   |   |   DataAccessLayer.csproj.nuget.g.props
|   |   |   DataAccessLayer.csproj.nuget.g.targets
|   |   |   project.assets.json
|   |   |   project.nuget.cache
|   |   |
|   |   \---Debug
|   |       \---net6.0
|   |           |   .NETCoreApp,Version=v6.0.AssemblyAttributes.cs
|   |           |   DataAccessLayer.AssemblyInfo.cs
|   |           |   DataAccessLayer.AssemblyInfoInputs.cache
|   |           |   DataAccessLayer.assets.cache
|   |           |   DataAccessLayer.csproj.AssemblyReference.cache
|   |           |   DataAccessLayer.csproj.BuildWithSkipAnalyzers
|   |           |   DataAccessLayer.csproj.CopyComplete
|   |           |   DataAccessLayer.csproj.CoreCompileInputs.cache
|   |           |   DataAccessLayer.csproj.FileListAbsolute.txt
|   |           |   DataAccessLayer.dll
|   |           |   DataAccessLayer.GeneratedMSBuildEditorConfig.editorconfig
|   |           |   DataAccessLayer.GlobalUsings.g.cs
|   |           |   DataAccessLayer.pdb
|   |           |
|   |           +---ref
|   |           |       DataAccessLayer.dll
|   |           |
|   |           \---refint
|   |                   DataAccessLayer.dll
|   |
|   \---Redis
|       +---Infrastructure
|       |       RedisCommand.cs
|       |
|       +---Interfaces
|       |       IPostsCacheRepository.cs
|       |       IRedisCommand.cs
|       |
|       \---Repository
|               PostsCacheRepository.cs
|
+---DotNetCoreFirstproject
|   |   .gitignore
|   |   appsettings.Development.json
|   |   appsettings.json
|   |   Dockerfile
|   |   Dockerfile.original
|   |   DotNetCoreFirstproject.csproj
|   |   Program.cs
|   |
|   +---bin
|   |   \---Debug
|   |       \---net6.0
|   |           |   APILayer.dll
|   |           |   APILayer.pdb
|   |           |   appsettings.Development.json
|   |           |   appsettings.json
|   |           |   Configurations.dll
|   |           |   Configurations.pdb
|   |           |   DataAccessLayer.dll
|   |           |   DataAccessLayer.pdb
|   |           |   DnsClient.dll
|   |           |   DotNetCoreFirstproject.deps.json
|   |           |   DotNetCoreFirstproject.dll
|   |           |   DotNetCoreFirstproject.exe
|   |           |   DotNetCoreFirstproject.pdb
|   |           |   DotNetCoreFirstproject.runtimeconfig.json
|   |           |   Elasticsearch.Net.dll
|   |           |   Helpers.dll
|   |           |   Helpers.pdb
|   |           |   Microsoft.DotNet.PlatformAbstractions.dll
|   |           |   Microsoft.Extensions.DependencyModel.dll
|   |           |   Microsoft.IdentityModel.Abstractions.dll
|   |           |   microsoft.identitymodel.dll
|   |           |   Microsoft.IdentityModel.JsonWebTokens.dll
|   |           |   Microsoft.IdentityModel.Logging.dll
|   |           |   Microsoft.IdentityModel.Tokens.dll
|   |           |   Microsoft.OpenApi.dll
|   |           |   Microsoft.Web.Infrastructure.dll
|   |           |   Microsoft.Win32.SystemEvents.dll
|   |           |   MiddlewareLayer.dll
|   |           |   MiddlewareLayer.pdb
|   |           |   Models.dll
|   |           |   Models.pdb
|   |           |   MongoDB.Bson.dll
|   |           |   MongoDB.Driver.Core.dll
|   |           |   MongoDB.Driver.dll
|   |           |   MongoDB.Libmongocrypt.dll
|   |           |   Nest.dll
|   |           |   Newtonsoft.Json.Bson.dll
|   |           |   Newtonsoft.Json.dll
|   |           |   Pipelines.Sockets.Unofficial.dll
|   |           |   ServiceLayer.dll
|   |           |   ServiceLayer.pdb
|   |           |   SharpCompress.dll
|   |           |   StackExchange.Redis.dll
|   |           |   Swashbuckle.AspNetCore.Swagger.dll
|   |           |   Swashbuckle.AspNetCore.SwaggerGen.dll
|   |           |   Swashbuckle.AspNetCore.SwaggerUI.dll
|   |           |   System.Configuration.ConfigurationManager.dll
|   |           |   System.Diagnostics.PerformanceCounter.dll
|   |           |   System.Drawing.Common.dll
|   |           |   System.IdentityModel.Tokens.Jwt.dll
|   |           |   System.Net.Http.Formatting.dll
|   |           |   System.Security.Cryptography.ProtectedData.dll
|   |           |   System.Security.Permissions.dll
|   |           |   System.Web.Helpers.dll
|   |           |   System.Web.Http.dll
|   |           |   System.Web.Mvc.dll
|   |           |   System.Web.Razor.dll
|   |           |   System.Web.WebPages.Deployment.dll
|   |           |   System.Web.WebPages.dll
|   |           |   System.Web.WebPages.Razor.dll
|   |           |   System.Windows.Extensions.dll
|   |           |
|   |           \---runtimes
|   |               +---linux
|   |               |   \---native
|   |               |           libmongocrypt.so
|   |               |           libsnappy64.so
|   |               |           libzstd.so
|   |               |
|   |               +---osx
|   |               |   \---native
|   |               |           libmongocrypt.dylib
|   |               |           libsnappy64.dylib
|   |               |           libzstd.dylib
|   |               |
|   |               +---unix
|   |               |   \---lib
|   |               |       \---netcoreapp3.0
|   |               |               System.Drawing.Common.dll
|   |               |
|   |               \---win
|   |                   +---lib
|   |                   |   +---netcoreapp2.0
|   |                   |   |       System.Diagnostics.PerformanceCounter.dll
|   |                   |   |
|   |                   |   +---netcoreapp3.0
|   |                   |   |       Microsoft.Win32.SystemEvents.dll
|   |                   |   |       System.Drawing.Common.dll
|   |                   |   |       System.Windows.Extensions.dll
|   |                   |   |
|   |                   |   \---netstandard2.0
|   |                   |           System.Security.Cryptography.ProtectedData.dll
|   |                   |
|   |                   \---native
|   |                           libzstd.dll
|   |                           mongocrypt.dll
|   |                           snappy32.dll
|   |                           snappy64.dll
|   |
|   +---obj
|   |   |   DotNetCoreFirstproject.csproj.nuget.dgspec.json
|   |   |   DotNetCoreFirstproject.csproj.nuget.g.props
|   |   |   DotNetCoreFirstproject.csproj.nuget.g.targets
|   |   |   project.assets.json
|   |   |   project.nuget.cache
|   |   |   staticwebassets.pack.sentinel
|   |   |
|   |   \---Debug
|   |       \---net6.0
|   |           |   .NETCoreApp,Version=v6.0.AssemblyAttributes.cs
|   |           |   apphost.exe
|   |           |   DotNetCoreFirstproject.AssemblyInfo.cs
|   |           |   DotNetCoreFirstproject.AssemblyInfoInputs.cache
|   |           |   DotNetCoreFirstproject.assets.cache
|   |           |   DotNetCoreFirstproject.csproj.AssemblyReference.cache
|   |           |   DotNetCoreFirstproject.csproj.CopyComplete
|   |           |   DotNetCoreFirstproject.csproj.CoreCompileInputs.cache
|   |           |   DotNetCoreFirstproject.csproj.FileListAbsolute.txt
|   |           |   DotNetCoreFirstproject.dll
|   |           |   DotNetCoreFirstproject.GeneratedMSBuildEditorConfig.editorconfig
|   |           |   DotNetCoreFirstproject.genruntimeconfig.cache
|   |           |   DotNetCoreFirstproject.GlobalUsings.g.cs
|   |           |   DotNetCoreFirstproject.MvcApplicationPartsAssemblyInfo.cache
|   |           |   DotNetCoreFirstproject.MvcApplicationPartsAssemblyInfo.cs
|   |           |   DotNetCoreFirstproject.pdb
|   |           |   staticwebassets.build.json
|   |           |
|   |           +---ref
|   |           |       DotNetCoreFirstproject.dll
|   |           |
|   |           +---refint
|   |           |       DotNetCoreFirstproject.dll
|   |           |
|   |           \---staticwebassets
|   \---Properties
|           launchSettings.json
|
+---Entities
|   |   Models.csproj
|   |
|   +---bin
|   |   \---Debug
|   |       \---net6.0
|   |               Entities.deps.json
|   |               Entities.dll
|   |               Entities.pdb
|   |               Models.deps.json
|   |               Models.dll
|   |               Models.pdb
|   |
|   +---ControllerModels
|   |       APIHealthResponse.cs
|   |       CustomerRequest.cs
|   |       CustomErrorResponse.cs
|   |       GeneralResponse.cs
|   |       LogoutRequest.cs
|   |       LogoutResponse.cs
|   |       PostsResponse.cs
|   |       TopPostsResponse.cs
|   |       UserLoginRequest.cs
|   |       UserLoginResponse.cs
|   |       UserSignupRequest.cs
|   |       UserSignupResponse.cs
|   |
|   +---DataAccessLayerModels
|   |       ControllerRequestResponseLog.cs
|   |       Customer.cs
|   |       TopPosts.cs
|   |
|   +---HelpersModels
|   |       CreateUserErrorResponse.cs
|   |       CreateUserRequest.cs
|   |       CustomAppError.cs
|   |       CustomKeycloakError.cs
|   |       DecodedToken.cs
|   |       KeycloakGeneralError.cs
|   |       TokenResponse.cs
|   |
|   \---obj
|       |   Entities.csproj.nuget.dgspec.json
|       |   Entities.csproj.nuget.g.props
|       |   Entities.csproj.nuget.g.targets
|       |   Models.csproj.nuget.dgspec.json
|       |   Models.csproj.nuget.g.props
|       |   Models.csproj.nuget.g.targets
|       |   project.assets.json
|       |   project.nuget.cache
|       |
|       \---Debug
|           \---net6.0
|               |   .NETCoreApp,Version=v6.0.AssemblyAttributes.cs
|               |   Entities.AssemblyInfo.cs
|               |   Entities.AssemblyInfoInputs.cache
|               |   Entities.assets.cache
|               |   Entities.csproj.AssemblyReference.cache
|               |   Entities.csproj.BuildWithSkipAnalyzers
|               |   Entities.csproj.CoreCompileInputs.cache
|               |   Entities.csproj.FileListAbsolute.txt
|               |   Entities.dll
|               |   Entities.GeneratedMSBuildEditorConfig.editorconfig
|               |   Entities.GlobalUsings.g.cs
|               |   Entities.pdb
|               |   Models.AssemblyInfo.cs
|               |   Models.AssemblyInfoInputs.cache
|               |   Models.assets.cache
|               |   Models.csproj.AssemblyReference.cache
|               |   Models.csproj.BuildWithSkipAnalyzers
|               |   Models.csproj.CoreCompileInputs.cache
|               |   Models.csproj.FileListAbsolute.txt
|               |   Models.dll
|               |   Models.GeneratedMSBuildEditorConfig.editorconfig
|               |   Models.GlobalUsings.g.cs
|               |   Models.pdb
|               |
|               +---ref
|               |       Entities.dll
|               |       Models.dll
|               |
|               \---refint
|                       Entities.dll
|                       Models.dll
|
+---Helpers
|   |   Helpers.csproj
|   |
|   +---AppExceptionHelpers
|   |       AppException.cs
|   |       DataNotFoundException.cs
|   |       ElasticSearchException.cs
|   |       EmailFormatException.cs
|   |       HashFailedException.cs
|   |       KeycloakException.cs
|   |       MalformedTokenException.cs
|   |       MandatoryRequestBodyParametersException.cs
|   |       MandatoryRequestQueryParamsException.cs
|   |       MandatoryRequestTokenHeadersException.cs
|   |       MongoDBConnectionException.cs
|   |       RedisDBConnectionException.cs
|   |       TokenNotActiveException.cs
|   |
|   +---bin
|   |   \---Debug
|   |       \---net6.0
|   |               Helpers.deps.json
|   |               Helpers.dll
|   |               Helpers.pdb
|   |               Models.dll
|   |               Models.pdb
|   |
|   +---CryptoHelpers
|   |       CryptoHelper.cs
|   |
|   +---FileHelpers
|   |       FileHelper.cs
|   |
|   +---HttpClientHelpers
|   |       HttpClientHelper.cs
|   |       PingHelper.cs
|   |
|   +---LoginHelpers
|   |       LoginHelper.cs
|   |
|   +---obj
|   |   |   Helpers.csproj.nuget.dgspec.json
|   |   |   Helpers.csproj.nuget.g.props
|   |   |   Helpers.csproj.nuget.g.targets
|   |   |   project.assets.json
|   |   |   project.nuget.cache
|   |   |
|   |   \---Debug
|   |       \---net6.0
|   |           |   .NETCoreApp,Version=v6.0.AssemblyAttributes.cs
|   |           |   Helpers.AssemblyInfo.cs
|   |           |   Helpers.AssemblyInfoInputs.cache
|   |           |   Helpers.assets.cache
|   |           |   Helpers.csproj.AssemblyReference.cache
|   |           |   Helpers.csproj.BuildWithSkipAnalyzers
|   |           |   Helpers.csproj.CopyComplete
|   |           |   Helpers.csproj.CoreCompileInputs.cache
|   |           |   Helpers.csproj.FileListAbsolute.txt
|   |           |   Helpers.dll
|   |           |   Helpers.GeneratedMSBuildEditorConfig.editorconfig
|   |           |   Helpers.GlobalUsings.g.cs
|   |           |   Helpers.pdb
|   |           |
|   |           +---ref
|   |           |       Helpers.dll
|   |           |
|   |           \---refint
|   |                   Helpers.dll
|   |
|   +---StringHelpers
|   |       StringHelper.cs
|   |
|   +---TokenHelpers
|   |       TokenHelper.cs
|   |
|   \---ValidationHelpers
|           EmailValidation.cs
|
\---MiddlewareLayer
    |   ErrorHandlerMiddleware.cs
    |   LoggingMiddleware.cs
    |   MiddlewareLayer.csproj
    |   RequestQueryParamsControlMiddleware.cs
    |   ResponseReadableStreamMiddleware.cs
    |   SessionStateControlMiddleware.cs
    |   TokenHeadersControlMiddleware.cs
    |
    +---bin
    |   \---Debug
    |       \---net6.0
    |               Configurations.dll
    |               Configurations.pdb
    |               DataAccessLayer.dll
    |               DataAccessLayer.pdb
    |               Helpers.dll
    |               Helpers.pdb
    |               MiddlewareLayer.deps.json
    |               MiddlewareLayer.dll
    |               MiddlewareLayer.pdb
    |               Models.dll
    |               Models.pdb
    |               ServiceLayer.dll
    |               ServiceLayer.pdb
    |
    \---obj
        |   MiddlewareLayer.csproj.nuget.dgspec.json
        |   MiddlewareLayer.csproj.nuget.g.props
        |   MiddlewareLayer.csproj.nuget.g.targets
        |   project.assets.json
        |   project.nuget.cache
        |
        \---Debug
            \---net6.0
                |   .NETCoreApp,Version=v6.0.AssemblyAttributes.cs
                |   MiddlewareLayer.AssemblyInfo.cs
                |   MiddlewareLayer.AssemblyInfoInputs.cache
                |   MiddlewareLayer.assets.cache
                |   MiddlewareLayer.csproj.AssemblyReference.cache
                |   MiddlewareLayer.csproj.BuildWithSkipAnalyzers
                |   MiddlewareLayer.csproj.CopyComplete
                |   MiddlewareLayer.csproj.CoreCompileInputs.cache
                |   MiddlewareLayer.csproj.FileListAbsolute.txt
                |   MiddlewareLayer.dll
                |   MiddlewareLayer.GeneratedMSBuildEditorConfig.editorconfig
                |   MiddlewareLayer.GlobalUsings.g.cs
                |   MiddlewareLayer.pdb
                |
                +---ref
                |       MiddlewareLayer.dll
                |
                \---refint
                        MiddlewareLayer.dll
```

## Contributing

#### Bug Reports & Feature Requests

Please use the Github issues.

#### Developing

PRs are welcome.
