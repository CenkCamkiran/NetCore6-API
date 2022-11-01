using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurations
{
	public partial class AppConfiguration
	{
		protected string? Host { get; set; }
		protected string? Username { get; set; }
		protected string? MSSQLPassword { get; set; }	
		protected string? DBName { get; set; }	
	}
}
