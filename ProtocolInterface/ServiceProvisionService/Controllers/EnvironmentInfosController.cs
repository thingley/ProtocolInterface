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
			string errorMessage;
			EnvironmentInfo? environmentInfo = _database.GetEnvironmentInfo(out errorMessage);

			if (errorMessage != string.Empty)
				return BadRequest(errorMessage);
			else if (environmentInfo == null)
				return NotFound();
			else
				return Ok(environmentInfo);
		}
	}
}
