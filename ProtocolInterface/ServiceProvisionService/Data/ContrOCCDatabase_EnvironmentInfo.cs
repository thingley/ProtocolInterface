using Microsoft.Data.SqlClient;
using System.Data;

using ServiceProvisionService.Models;
using Shared;

namespace ServiceProvisionService.Data
{
	public partial class ContrOCCDatabase
	{
		public EnvironmentInfo? GetEnvironmentInfo(out string errorMessage)
		{
			EnvironmentInfo? result = null;
			errorMessage = string.Empty;

			void DoGetEnvironmentInfo(SqlConnection connection)
			{
				SqlCommand command = new SqlCommand()
				{
					Connection = connection,
					CommandType = CommandType.StoredProcedure,
					CommandText = "dbo.Interface_GenericWSI_EnvironmentInfo_Select",
				};

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

			ActionError actionError = ExecuteNonTransactionedAction(DoGetEnvironmentInfo);
			errorMessage = actionError.ToString();

			return result;
		}

	}
}
