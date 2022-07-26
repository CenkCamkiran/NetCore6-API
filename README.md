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

## Structure

```
|   .gitignore //Gitignore file
|   .dockerignore //Dockerignore file
|   App.config //Config file that holds PostgreSQL Connection String and OpenWeather API Token
|   Program.cs //Main Function
|   Dockerfile //Dockerfile for building Image
|
+---DockerPostgreSQLFile
|       docker-compose.yml //DockerCompose file for PostgreSQL
|
+---Database
|   \---PostgreSQL
|       +---Configuration
|       |       PostgreCommand.cs //Helper class that prepares parameters for Stored Procedures, Postgre functions and initializes NpgsqlCommand object
|       |       PostgreConnection.cs //A class that connects to PostgreSQL Database and initializes connection object
|       |
|       +---Interfaces
|       |       IPostgreOperations.cs //PostgreSQL interface that holds CRUD functions (Select and Insert at the moment)
|       |
|       +---Operations
|       |       PostgreOperations.cs //Operation layer class
|       |
|       \---SQL
|               PostgreSQLDataLayer.cs //A class that runs Stored Procedures and Postgre Functions in PostgreSQL
|
+---Models
|       CheckWeatherParams.cs // Custom model that used for checking data in PostgreSQL (The purpose is avoid duplicate data)
|       WeatherData.cs // JSON Response model that coming from OpenWeather API
|
|
\---WebServiceClient
|        ServiceClient.cs //A class that sends request to OpenWeather API and deserializes the response
|
\---PostgreSQLScripts //SQL scripts for PostgreSQL (Create Table, Create Procedure and Create Function queries)
        Function.sql
        StoredProcedure.sql
        Table.sql
```

## Contributing

#### Bug Reports & Feature Requests

Please use the Github issues.

#### Developing

PRs are welcome.
