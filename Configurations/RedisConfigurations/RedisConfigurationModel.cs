using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurations
{
	public partial class AppConfiguration
    {
        protected string? RedisHost { get; set; }
        protected string? Password { get; set; }
    }
}
