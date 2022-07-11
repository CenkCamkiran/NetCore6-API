using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APILayer.Controllers.Test
{

	[ApiController]
	public class TestMongoDBController : ControllerBase
	{

		[HttpGet]
		[Route("rest/api/v1/main/[controller]")]
		public object TestConnection()
		{
			var cenk = new
			{
				number = 5,
				name = "Cenk"
			};

			try
			{
				MongoClient dbClient = new MongoClient("mongodb://mongo_admin:3%23LeaQEfxHLP%23xp%25q22st@35.198.138.249:27017/analytics?authMechanism=SCRAM-SHA-256&authSource=admin");

				var dbList = dbClient.ListDatabases().ToList();

				Console.WriteLine("The list of databases on this server is: ");
				foreach (var db in dbList)
				{
					Console.WriteLine(db);
				}

				/**
				 * 
				 * { "name" : "admin", "sizeOnDisk" : NumberLong(102400), "empty" : false }
                   { "name" : "analytics", "sizeOnDisk" : NumberLong(9904128), "empty" : false }
                   { "name" : "config", "sizeOnDisk" : NumberLong(110592), "empty" : false }
                   { "name" : "local", "sizeOnDisk" : NumberLong(73728), "empty" : false }
				 * 
				 */

			}
			finally
			{

			}

			return cenk;
		}

	}
}
