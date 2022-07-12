using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.AppExceptionHelpers
{
	public class MongoDBConnectionException : Exception
	{
		public MongoDBConnectionException()
		{
		}

		public MongoDBConnectionException(string? message) : base(message)
		{
		}
	}
}
