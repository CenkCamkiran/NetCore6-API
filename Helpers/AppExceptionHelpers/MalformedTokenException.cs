using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.AppExceptionHelpers
{
	public class MalformedTokenException : Exception
	{
		public MalformedTokenException()
		{
		}

		public MalformedTokenException(string? message) : base(message)
		{
		}
	}
}
