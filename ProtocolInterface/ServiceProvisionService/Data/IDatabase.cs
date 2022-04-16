using ServiceProvisionService.Models;

namespace ServiceProvisionService.Data
{

	public interface IDatabase
	{
		EnvironmentInfo? GetEnvironmentInfo(out string errorString);
	}
}
