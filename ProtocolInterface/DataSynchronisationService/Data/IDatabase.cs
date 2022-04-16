using DataSynchronisationService.Models;

namespace DataSynchronisationService.Data
{
	public interface IDatabase
	{
		IEnumerable<ReasonForEndDate> GetReasonForEndDates(out string errorMessage, int? sharedEntityIdentifier = null);
		IEnumerable<Service> GetServices();
		IEnumerable<ServiceFolder> GetServiceFolders();
		IEnumerable<ServiceType> GetServiceTypes();
	}
}
