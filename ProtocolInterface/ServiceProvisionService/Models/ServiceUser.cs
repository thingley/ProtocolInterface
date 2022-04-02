namespace ServiceProvisionService.Models
{
	public class ServiceUser
	{
		public string Identifier { get; set; } = string.Empty;
		public string Title { get; set; } = string.Empty;
		public string Forename { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
		public string NationalInsuranceNumber { get; set; } = string.Empty;
		public string SocialSecurityNumber { get; set; } = string.Empty;
		public string DateOfBirth { get; set; }
		public string DateOfDeath { get; set; }
		public string Gender { get; set; } = string.Empty;
	}
}
