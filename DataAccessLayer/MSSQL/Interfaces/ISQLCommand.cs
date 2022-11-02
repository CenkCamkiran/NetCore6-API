using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MSSQL.Interfaces
{
	public interface ISQLCommand<TRequest, TResponse>
	{
		TResponse ExecuteQuery();

		void ExecuteNonQuery();
	}
}
