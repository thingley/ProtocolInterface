using Microsoft.Data.SqlClient;
using System.Data;

using ServiceProvisionService.Models;

namespace ServiceProvisionService.Data
{
	public class ContrOCCDatabase : IDatabase
	{
		private readonly IServiceProvider _serviceProvider;

		public ContrOCCDatabase(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public EnvironmentInfo? GetEnvironmentInfo()
		{
			EnvironmentInfo? result = null;

			using (IDbConnection connection = _serviceProvider.GetRequiredService<IDbConnection>())
			{
				IDbCommand command = connection.CreateCommand();
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "dbo.Interface_GenericWSI_EnvironmentInfo_Select";

				connection.Open();

				using (IDataReader dr = command.ExecuteReader())
				{
					if (dr.Read())
					{
						result = new EnvironmentInfo()
						{
							ServerName = (string)dr["ServerName"],
							DatabaseName = (string)dr["DatabaseName"],
							DatabaseVersion = (string)dr["DatabaseVersion"],
							DatabasePatchNumber = (int)dr["DatabasePatchNumber"],
						};
					}
				}
			}

			return result;
		}
	}
}
