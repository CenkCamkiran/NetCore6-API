using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.AppExceptionHelpers
{
	public class TokenNotActiveException : Exception
	{
		public TokenNotActiveException()
		{
		}

		public TokenNotActiveException(string? message) : base(message)
		{
		}
	}
}
