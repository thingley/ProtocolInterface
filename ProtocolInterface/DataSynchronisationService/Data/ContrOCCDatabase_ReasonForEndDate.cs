using Microsoft.Data.SqlClient;
using System.Data;

using DataSynchronisationService.Models;
using Shared;

namespace DataSynchronisationService.Data
{
	public partial class ContrOCCDatabase
	{
		public IEnumerable<ReasonForEndDate> GetReasonForEndDates(out string errorMessage, int? sharedEntityIdentifier = null)
		{
			List<ReasonForEndDate> result = new List<ReasonForEndDate>();
			errorMessage = string.Empty;

			void DoGetReasonForEndDates(SqlConnection connection)
			{
				SqlCommand command = new SqlCommand()
				{
					Connection = connection,
					CommandType = CommandType.StoredProcedure,
					CommandText = "dbo.Controcc_ProtocolInterface_RetrieveData_ReasonForEndDate",
				};

				command.Parameters.Add(new SqlParameter()
				{
					ParameterName = "@SharedEntityIdentifier",
					SqlDbType = SqlDbType.Int,
					SqlValue = ((sharedEntityIdentifier == null) ? DBNull.Value : sharedEntityIdentifier),
				});

				using (SqlDataReader dr = command.ExecuteReader())
				{
					while (dr.Read())
					{
						result.Add(new ReasonForEndDate()
						{
							Identifier = DBIntToProtocolIdentifier(dr["Identifier"]),
							Name = DBStringToProtocolString(dr["Name"]),
							IsExceptional = DBBoolToProtocolBool(dr["IsExceptional"]),
							IsDeleted = DBBoolToProtocolBool(dr["IsDeleted"]),
						});
					}
				}
			}

			ActionError actionError = ExecuteNonTransactionedAction(DoGetReasonForEndDates);
			errorMessage = actionError.ToString();

			return result;
		}
	}
}
