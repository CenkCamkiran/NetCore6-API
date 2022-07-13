using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ControllerModels
{
	public class LogoutRequest
	{
		public string accessToken { get; set; }
		public string refreshToken { get; set; }
	}
}
