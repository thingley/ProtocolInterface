using Microsoft.AspNetCore.Mvc;

using DataSynchronisationService.Data;
using DataSynchronisationService.Models;

namespace DataSynchronisationService.Controllers
{
	[Route("api/services")]
	[ApiController]
	public class ServicesController : ControllerBase
	{
		private readonly IDatabase _database;

		public ServicesController(IDatabase database)
		{
			_database = database;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Service>> GetServices()
		{
				var services = _database.GetServices();
				return Ok(services);
		}

		[HttpGet("{identifier}")]
		public ActionResult<Service> GetService(string identifier)
		{
			var service = _database.GetService(identifier);
			//return NotFound();
			//return BadRequest();
			return Ok(service);
		}
	}
}
