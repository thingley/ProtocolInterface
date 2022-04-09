using Microsoft.AspNetCore.Mvc;

using ServiceProvisionService.Data;
using ServiceProvisionService.Models;

namespace ServiceProvisionService.Controllers
{
	[Route("api/environmentinfos")]
	[ApiController]
	public class EnvironmentInfosController: ControllerBase
	{
		private readonly IDatabase _database;

		public EnvironmentInfosController(IDatabase database)
		{
			_database = database;
		}

		[HttpGet]
		public ActionResult<EnvironmentInfo> GetEnvironmentInfo()
		{
			var environmentInfo = _database.GetEnvironmentInfo();

			return Ok(environmentInfo);
		}
	}
}
