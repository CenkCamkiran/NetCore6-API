using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ControllerModels
{
	public class TestQueueRequest
	{
		public string message { get; set; }	
		public string queue { get; set; }	
		public string exchange { get; set; }	
		public string routingKey { get; set; }
	}
}


