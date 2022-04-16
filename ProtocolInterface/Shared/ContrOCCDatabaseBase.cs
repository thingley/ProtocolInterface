using Microsoft.Data.SqlClient;

using System;
using System.Data;

namespace Shared
{
	public class ContrOCCDatabaseBase
	{
		private readonly Func<SqlConnection> _getConnection;

		public ContrOCCDatabaseBase(Func<SqlConnection> getConnection)
		{
			_getConnection = getConnection;
		}

		protected ActionError ExecuteNonTransactionedAction(Action<SqlConnection> actionToPerform)
		{
			string errorMessage = string.Empty;
			int errorNumber = 0;

			try
			{
				using (SqlConnection connection = _getConnection())
				{
					connection.Open();
					actionToPerform(connection);
				}
			}
			catch (SqlException ex)
			{
				errorMessage = ex.Message;
				errorNumber = ex.Number;
			}
			catch (SystemException ex)
			{
				errorMessage = ex.Message;
			}

			return new ActionError(errorMessage, errorNumber);
		}

		protected ActionError ExecuteTransactionedAction(Action<SqlConnection, SqlTransaction> actionToPerform)
		{
			SqlTransaction? transaction = null;
			string errorMessage = string.Empty;
			int errorNumber = 0;

			try
			{
				using (SqlConnection connection = _getConnection())
				{
					connection.Open();
					transaction = connection.BeginTransaction();
					actionToPerform(connection, transaction);
					transaction.Commit();
				}
			}
			catch (SqlException ex)
			{
				transaction?.Rollback();
				errorMessage = ex.Message;
				errorNumber = ex.Number;
			}
			catch (SystemException ex)
			{
				transaction?.Rollback();
				errorMessage = ex.Message;
			}

			return new ActionError(errorMessage, errorNumber);
		}

	}
}
