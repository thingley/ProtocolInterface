using ServiceProvisionService.Models;

namespace ServiceProvisionService.Data
{

	public interface IDatabase
	{
		#region ClientGroup

		IEnumerable<ClientGroup> GetClientGroups();
		ClientGroup GetClientGroup(string identifier);

		#endregion ClientGroup

		#region ServiceUser

		IEnumerable<ServiceUser> GetServiceUsers();
		ServiceUser GetServiceUser(string identifier);

		#endregion ServiceUser
	}
}
