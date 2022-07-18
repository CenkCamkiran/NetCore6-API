using Configurations;
using Helpers.AppExceptionHelpers;
using Models.HelpersModels;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Net;

namespace DataAccessLayer.Redis.Infrastructure
{
	public class RedisConnection
	{
		private ConnectionMultiplexer redisConnection;
		public ConnectionMultiplexer connection { get => redisConnection; }

		public RedisConnection()
		{
			try
			{
				AppConfiguration appConfiguration = new AppConfiguration();
				Dictionary<string, string> redisConfig = appConfiguration.GetRedisConfig();

				var options = ConfigurationOptions.Parse(redisConfig["RedisHost"]);
				options.Password = redisConfig["Password"];

				redisConnection = ConnectionMultiplexer.Connect(options);
			}
			catch (Exception exception)
			{
				CustomAppError errorModel = new CustomAppError();
				errorModel.ErrorMessage = exception.Message.ToString();
				errorModel.ErrorCode = ((int)HttpStatusCode.InternalServerError).ToString();

				throw new RedisDBConnectionException(JsonConvert.SerializeObject(errorModel));
			}
		}

	}
}
