using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.AppExceptionHelpers
{
	public class DataNotFoundException : Exception
	{
		public DataNotFoundException()
		{
		}

		public DataNotFoundException(string? message) : base(message)
		{
		}
	}
}
