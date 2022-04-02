using ServiceProvisionService.Models;

namespace ServiceProvisionService.Data
{
	public class ProductionDatabase : IDatabase
	{
		public IEnumerable<ClientGroup> GetClientGroups()
		{
			throw new NotImplementedException();
		}

		public ClientGroup GetClientGroup(string identifier)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ServiceUser> GetServiceUsers()
		{
			throw new NotImplementedException();
		}

		public ServiceUser GetServiceUser(string identifier)
		{
			throw new NotImplementedException();
		}
	}
}
