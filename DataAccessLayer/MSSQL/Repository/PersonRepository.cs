using DataAccessLayer.MSSQL.Infrastructure;
using DataAccessLayer.MSSQL.Interfaces;
using Models.ControllerModels;
using MongoDB.Driver;
using Nest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MSSQL.Repository
{
	public class PersonRepository : IPersonRepository
	{
		private readonly IDbConnection _dbConnection;

		private const string SP_GETPERSON_BY_ID = "GETPERSON_BY_ID";
		private const string SP_INSERT_NEWPERSON = "INSERT_NEWPERSON";

		public PersonRepository(IDbConnection dbConnection)
		{
			_dbConnection = dbConnection;
		}

		public PersonRequest GetPersonById(string Id)
		{
			PersonRequest personRequest = new PersonRequest();

			try
			{
				SqlCommand command = new SqlCommand();
				command.Connection = (SqlConnection)_dbConnection;
				command.CommandText = SP_GETPERSON_BY_ID;
				command.CommandType = CommandType.StoredProcedure;

				command.Parameters.Add("@PERSON_ID", SqlDbType.Int).Value = Convert.ToInt32(Id);

				_dbConnection.Open();

				using (SqlDataReader reader = command.ExecuteReader())
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							personRequest.FirstName = reader.GetString("FIRST_NAME");
							personRequest.LastName = reader.GetString("LAST_NAME");
							personRequest.Age = reader.GetInt32("AGE");
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
			finally
			{
				_dbConnection.Close();
			}

			return personRequest;
		}

		public void InsertNewPerson(PersonRequest personData)
		{
			try
			{
				SqlCommand command = new SqlCommand();
				command.Connection = (SqlConnection)_dbConnection;
				command.CommandText = SP_INSERT_NEWPERSON;
				command.CommandType = CommandType.StoredProcedure;

				command.Parameters.Add("@FIRST_NAME", SqlDbType.VarChar).Value = personData.FirstName;
				command.Parameters.Add("@LAST_NAME", SqlDbType.VarChar).Value = personData.LastName;
				command.Parameters.Add("@AGE", SqlDbType.Int).Value = personData.Age;

				//sqlCommand.Parameters.AddWithValue("@BusinessEntityID", System.Data.SqlDbType.Int).Value = updateEmployeeModel.BusinessEntityID;
				//UPDATE, INSERT ve DELETE deyimleri için, dönüş değeri komutundan etkilenen satır sayısıdır. Diğer tüm deyim türleri için, dönüş değeri-1 ' dir.
				//this.sqlConnection.Open();
				//int rowAffected = sqlCommand.ExecuteNonQuery();

				_dbConnection.Open();

				command.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				throw new Exception();
			}
			finally
			{
				_dbConnection.Close();
			}

		}
	}
}
