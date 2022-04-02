using ServiceProvisionService.Models;

namespace ServiceProvisionService.Data
{
	public class MockDatabase : IDatabase
	{
		public IEnumerable<ClientGroup> GetClientGroups()
		{
			ClientGroup residential = GetClientGroup("RES");
			ClientGroup nonResidential = GetClientGroup("NONRES");

			return new List<ClientGroup>() { residential, nonResidential };
		}

		public ClientGroup GetClientGroup(string identifier)
		{
			ClientGroup result;

			switch (identifier)
			{
				case "RES":
					result = new ClientGroup()
					{
						Identifier = "RES",
						Name = "Residential Client Group",
						IsDeleted = false,
					};
					break;
				case "NONRES":
					result = new ClientGroup()
					{
						Identifier = "NONRES",
						Name = "Non-Residential Client Group",
						IsDeleted = false,
					};
					break;
				default:
					throw new ArgumentException($@"No Client Group found for identifier '{identifier}'");
					break;
			}

			return result;
		}

		public IEnumerable<ServiceUser> GetServiceUsers()
		{
			ServiceUser betty = GetServiceUser("BS001");
			ServiceUser joe = GetServiceUser("JB001");

			return new List<ServiceUser>() { betty, joe };
		}

		public ServiceUser GetServiceUser(string identifier)
		{
			ServiceUser result;

			switch (identifier)
			{
				case "BS001":
					result = new ServiceUser()
					{
						Identifier = "BS001",
						Title = "Ms",
						Forename = "Betty",
						Surname = "Swollocks",
						DateOfBirth = "19450101",
						DateOfDeath = "",
						Gender = "FEMALE",
						NationalInsuranceNumber = "SW123456A",
						SocialSecurityNumber = "12345678",
					};

					break;
				case "JB001":
					result = new ServiceUser()
					{
						Identifier = "JB001",
						Title = "Mr",
						Forename = "Joe",
						Surname = "Blob",
						DateOfBirth = "19460202",
						DateOfDeath = "",
						Gender = "FEMALE",
						NationalInsuranceNumber = "SW123456A",
						SocialSecurityNumber = "12345678",
					};
					break;
				default:
					throw new ArgumentException($@"No Service User found for identifier '{identifier}'");
					break;
			}

			return result;
		}
	}
}
