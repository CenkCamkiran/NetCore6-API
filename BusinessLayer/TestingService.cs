using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
	public class TestingService : ITesting
	{
		public Task DoSomethingAsync()
		{
			return Task.FromResult("Async completed");
		}

		public string DoSomethingSync()
		{
			return "Sync completed!";
		}
	}
}
