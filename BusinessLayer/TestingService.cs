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
		public async Task<string> DoSomethingAsync()
		{
			await Task.Delay(5000);
			return "Async completed";
		}

		public string DoSomethingSync()
		{
			return "Sync completed!";
		}
	}
}
