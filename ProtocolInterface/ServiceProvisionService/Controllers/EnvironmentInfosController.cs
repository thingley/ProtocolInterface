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
			try
			{
				EnvironmentInfo? environmentInfo = _database.GetEnvironmentInfo();

				if (environmentInfo == null)
					return NotFound();
				else
					return Ok(environmentInfo);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}				
		}
	}
}
