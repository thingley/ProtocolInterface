namespace ServiceProvisionService.Models
{
	public class EnvironmentInfo
	{
		public string ServerName { get; set; } = string.Empty;
		public string DatabaseName { get; set; } = string.Empty;
		public string DatabaseVersion { get; set; } = string.Empty;
		public int DatabasePatchNumber { get; set; } = 0;
	}
}
