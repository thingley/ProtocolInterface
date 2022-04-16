using Microsoft.Data.SqlClient;
using System.Data;

using ServiceProvisionService.Models;
using Shared;

namespace ServiceProvisionService.Data
{
	public partial class ContrOCCDatabase : ContrOCCDatabaseBase, IDatabase
	{
		public ContrOCCDatabase(IServiceProvider serviceProvider) : base(() => serviceProvider.GetRequiredService<SqlConnection>())
		{ }
	}
}
