using DataSynchronisationService.Models;

namespace DataSynchronisationService.Data
{
	public class ContrOCCDatabase : IDatabase
	{
		public IEnumerable<Service> GetServices()
		{
			throw new NotImplementedException();
		}

		public Service GetService(string identifier)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ServiceFolder> GetServiceFolders()
		{
			throw new NotImplementedException();
		}

		public ServiceFolder GetServiceFolder(string identifier)
		{
			throw new NotImplementedException();
		}

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
