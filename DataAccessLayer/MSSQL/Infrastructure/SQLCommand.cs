using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MSSQL.Infrastructure
{
	public class SQLCommand<TModel>
	{
		private readonly SqlConnection sqlConnection;
	}
}
