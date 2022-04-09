using DataSynchronisationService.Models;

namespace DataSynchronisationService.Data
{
	public interface IDatabase
	{
		IEnumerable<Service> GetServices();
		Service GetService(string identifier);
		IEnumerable<ServiceFolder> GetServiceFolders();
		ServiceFolder GetServiceFolder(string identifier);
		IEnumerable<ServiceType> GetServiceTypes();
		ServiceFolder GetServiceType(string identifier);
	}
}
