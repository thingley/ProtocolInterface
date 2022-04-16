using Microsoft.Data.SqlClient;
using System.Data;

using DataSynchronisationService.Models;
using Shared;

namespace DataSynchronisationService.Data
{
	public partial class ContrOCCDatabase : ContrOCCDatabaseBase, IDatabase
	{
		public ContrOCCDatabase(IServiceProvider serviceProvider) : base(() => serviceProvider.GetRequiredService<SqlConnection>())
		{ }
	}
}
