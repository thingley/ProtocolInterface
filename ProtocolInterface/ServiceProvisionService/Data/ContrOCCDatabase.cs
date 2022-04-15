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

			using (SqlConnection connection = _serviceProvider.GetRequiredService<SqlConnection>())
			{
				SqlCommand command = new SqlCommand()
				{
					Connection = connection,
					CommandType = CommandType.StoredProcedure,
					CommandText = "dbo.Interface_GenericWSI_EnvironmentInfo_Select",
				};

				connection.Open();

				using (SqlDataReader dr = command.ExecuteReader())
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
