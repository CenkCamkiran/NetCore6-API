<div style="text-align: center">

<img src="https://cdn.dribbble.com/users/42044/screenshots/3005802/media/e9d2cfc8f3ccdedebef7a8af171fbd08.jpg" width=15% height=15%>

</div>

# API Project with .NET Core 6

<!-- [![Elastic Stack version](https://img.shields.io/badge/Elastic%20Stack-8.3.2-00bfb3?style=flat&logo=elastic-stack)](https://www.elastic.co/blog/category/releases)
[![Build Status](https://github.com/deviantony/docker-elk/workflows/CI/badge.svg?branch=main)](https://github.com/deviantony/docker-elk/actions?query=workflow%3ACI+branch%3Amain)
[![Join the chat at https://gitter.im/deviantony/docker-elk](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/deviantony/docker-elk?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge) -->

## Philosophy

Explanation of project

## Contents

- [API Project with .NET Core 6](#api-project-with-net-core-6)
  - [Philosophy](#philosophy)
  - [Contents](#contents)
  - [Features](#features)
  - [Requirements](#requirements)
    - [Docker installation](#docker-installation)
    - [ElasticSearch Installation](#elasticsearch-installation)
      - [Creation of Index on ElasticSearch-Kibana](#creation-of-index-on-elasticsearch-kibana)
    - [Kibana Installation](#kibana-installation)
    - [MongoDB Installation](#mongodb-installation)
      - [MongoDB Schema Validation Command](#mongodb-schema-validation-command)
    - [Keycloak Installation](#keycloak-installation)
      - [Keycloak Realm Configuration](#keycloak-realm-configuration)
    - [RabbitMQ Installation ????](#rabbitmq-installation-)
    - [Postman Collection](#postman-collection)
    - [Install project with Docker Container ???](#install-project-with-docker-container-)
  - [Structure](#structure)
  - [Contributing](#contributing)
  - [Bug Reports & Feature Requests](#bug-reports--feature-requests)
  - [Road Map](#road-map)

## Features

- Developed via Npgsql and NewtonsoftJson Library
- Uses MongoDB Database
- Uses ElasticSearch for logging request and responses
- Easy to deploy
- Can run on any platform (Mac, Linux ve Windows)
- It is API. Test on Postman!

## Requirements

> **Note** <br />
> Currently I use **Docker version 20.10.17, build 100c701** and **Docker Compose version v2.6.0** <br />
> Currently I use **Docker Compose version v2.6.0** <br />
> Currently I use **Centos 7 Linux** machine on Google Cloud. Check that out: https://cloud.google.com/ <br />

### Docker installation

Docker Engine and Docker Compose must be installed. Check out on Docker's offical site.

### ElasticSearch Installation

Follow the instructions below.

```bash
$ export ELASTIC_VERSION="8.2.3" #This command must be executed due to installation of Logstash, ElasticSearch and Kibana properly. I used version 8.2.3
$ git clone https://github.com/deviantony/docker-elk #This repository contains all information about installation of Logstash, ElasticSearch and Kibana.
$ #Alter xpack.license.self_generated.type property to 'basic' inside of elasticsearch/config/elasticsearch.yml file in https://github.com/deviantony/docker-elk repository due to licence purposes.
$ #If you encounter licence problems, go to License management menu on Kibana and change your licence to basic. (Or paid if you want to use all features of Kibana)
$ docker-compose up -d #This command must be executed in the same directory of docker-compose file #See more information on https://github.com/deviantony/docker-elk . You can change docker-compose.yml file for your preferences.
```

#### Creation of Index on ElasticSearch-Kibana

1. Open Dev Console on Kibana.

2. Run command below on Kibana Dev Console.

   ```bash
   $ PUT /controller-logs-index
    {
        "settings": {
            "index": {
                "number_of_shards": 1,
                "number_of_replicas": 0
            }
        },
        "mappings": {
            "properties": {
                "RequestJSONBody": {
                    "type": "flattened"
                },
                "ResponseJSONBody": {
                    "type": "flattened"
                }
            }
        }
    }
   ```

3. Go Index Management on Kibana. Make sure that index created.

### Kibana Installation

Follow the instructions below.

1. After installation of Logstash, ElasticSearch and Kibana from https://github.com/deviantony/docker-elk repository, Kibana will occur errors. To fix that, stop and remove kibana docker container.

   ```bash
   $ docker stop kibana_container_id
   $ docker container rm  kibana_container_id
   ```

2. Run commands below.

   ```bash
   $ docker-compose up -d #Run this command at the location of Kibana Folder (location of docker-compose.yml). Kibana Folder is in Docs folder. (Docs/Kibana/docker-compose.yml)
   ```

3. After installation of Kibana, you need to reset ceredentials of Kibana user in ElasticSearch. (Source: https://github.com/deviantony/docker-elk). This instruction have been written in README.

   ```bash
   $ docker-compose exec elasticsearch bin/elasticsearch-reset-password --batch --user kibana_system #Run this command and get credentials for kibana
   ```

### MongoDB Installation

Follow the instructions below.

```bash
$ docker-compose up -d #This command must be executed in the same directory of docker-compose file (inside of Docs/MongoDB/docker-compose.yml)
```

I recommend MongoDB Compass for UI of MongoDB. It is very useful tool. Check that out (https://www.mongodb.com/products/compass)

#### MongoDB Schema Validation Command

Run Mongosh bash command below.

```bash
db.runCommand({
    "collMod": "customers",
    "validator": {
        $jsonSchema: {
            "bsonType": "object",
            "description": "A document that defines customer",
            "required": ["username", "name", "address", "birthdate", "email"],
            "properties": {
                "username": {
                    "bsonType": "string",
                    "description": "Username field must be a string and is required"
                },
                "name": {
                    "bsonType": "string",
                    "description": "Name field must be a string and it is required"
                },
                "address": {
                    "bsonType": "string",
                    "description": "Address field must be a string and it is required"
                },
                "birthdate": {
                    "bsonType": "date",
                    "description": "Birthdate must be a string and it is required"
                },
                "email": {
                    "bsonType": "string",
                    "description": "Email field must be a string and it is required"
                },
                "active": {
                    "bsonType": "bool",
                    "description": "Active field must be a boolean"
                },
                "tier_and_details": {
                    "bsonType": "object",
                    "description": "TierAndDetails field must be a object"
                },
                "accounts": {
                    "bsonType": "array",
                    "description": "Accounts field must be a array"
                }
            },
        }
    }
})
```

### Keycloak Installation

First install openssl library in your Linux machine. Make sure update your linux machine. I use Centos 7 Linux machine.
Installation of openssl library for Centos 7: https://gist.github.com/fernandoaleman/5459173e24d59b45ae2cfc618e20fe06

If you use Ubuntu Linux machine, you should do some research on google :)

Follow the instructions below.

```bash
$ openssl req -newkey rsa:2048 -nodes \
  -keyout server.key.pem -x509 -days 3650 -out server.crt.pem #Used for generating ssl files.
$ chmod 755 server.key.pem #Give all permissions on file.
$ export KEYCLOAKPWD="*****" #Password for Keycloak Admin user
$ docker run -d --name keycloak -p 8443:8443 \
-e KEYCLOAK_ADMIN=admin \
-e KEYCLOAK_ADMIN_PASSWORD=${KEYCLOAKPWD} \
-e KC_HTTPS_CERTIFICATE_FILE=/root/keycloak/server.crt.pem \
-e KC_HTTPS_CERTIFICATE_KEY_FILE=/root/keycloak/server.key.pem \
-v $PWD/server.crt.pem:/root/keycloak/server.crt.pem \
-v $PWD/server.key.pem:/root/keycloak/server.key.pem \
-t quay.io/keycloak/keycloak:18.0.1 start-dev
```

There are other alternative installations of Keycloak. Source: https://stackoverflow.com/questions/49859066/keycloak-docker-https-required

#### Keycloak Realm Configuration

Import JSON file using Keycloak **Import** Menu

### RabbitMQ Installation ????

```bash
$
$
$
$
$
```

### Postman Collection

Collection file is in Docs/Postman Collection. Import and test API!

### Install project with Docker Container ???

Follow the instructions below.

```bash
$ git clone https://github.com/CenkCamkiran/OpenWeather-DotNet-Docker-Project.git
$ docker build -t weatherapp .
$ docker run -d --name openweatherapp -t weatherapp --restart on-failure
$ docker logs -t --since 1h //Watch the logs of container
```

## Structure

(Will be edited in the future. Delete dlls etc. only necessary files) (FILE STRUCTURE)

<!-- ```
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
``` -->

## Contributing

I am open every advice for my project. I am planning to improve myself on .NET Core 6. So don't hesitate comment on my project.

## Bug Reports & Feature Requests

Please use the Github issues.

## Road Map

- I want to use some Software Design Patterns on my project.
- RabbitMQ ????
- Unit Testing
- DevOps mechanism in the future. (Maybe Gitlab and Jenkins)
