using Microsoft.Data.SqlClient;
using System.Data;

using DataSynchronisationService.Models;
using Shared;

namespace DataSynchronisationService.Data
{
	public partial class ContrOCCDatabase
	{
		public IEnumerable<ServiceFolder> GetServiceFolders()
		{
			throw new NotImplementedException();
		}

		public ServiceFolder GetServiceFolder(string identifier)
		{
			throw new NotImplementedException();
		}
	}
}
