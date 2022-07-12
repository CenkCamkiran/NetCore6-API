using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.AppExceptionHelpers
{
	public class MandatoryRequestQueryParamsException : Exception
	{
		public MandatoryRequestQueryParamsException()
		{
		}

		public MandatoryRequestQueryParamsException(string? message) : base(message)
		{
		}
	}
}
