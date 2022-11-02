using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurations
{
	public partial class AppConfiguration
	{
		protected string? RabbitMQHost { get; set; }
		protected string? RabbitMQPort { get; set; }
		protected string? RabbitMQUsername { get; set; }
		protected string? RabbitMQPassword { get; set; }	
	}
}
