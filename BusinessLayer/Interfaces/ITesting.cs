using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
	public interface ITesting
	{
		Task<string> DoSomethingAsync();
		string DoSomethingSync();
	}
}
