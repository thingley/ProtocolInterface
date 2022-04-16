using Microsoft.Data.SqlClient;
using System.Data;

using DataSynchronisationService.Models;
using Shared;

namespace DataSynchronisationService.Data
{
	public partial class ContrOCCDatabase
	{
		public IEnumerable<ServiceType> GetServiceTypes()
		{
			throw new NotImplementedException();
		}

		public ServiceFolder GetServiceType(string identifier)
		{
			throw new NotImplementedException();
		}
	}
}
