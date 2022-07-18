using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.AppExceptionHelpers
{
	public class RedisDBConnectionException : Exception
	{
		public RedisDBConnectionException()
		{
		}

		public RedisDBConnectionException(string? message) : base(message)
		{
		}
	}
}
