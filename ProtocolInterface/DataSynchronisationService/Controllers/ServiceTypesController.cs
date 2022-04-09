using Microsoft.AspNetCore.Mvc;

using DataSynchronisationService.Data;
using DataSynchronisationService.Models;

namespace DataSynchronisationService.Controllers
{
	[Route("api/servicetypes")]
	[ApiController]
	public class ServiceTypesController : ControllerBase
	{
		private readonly IDatabase _database;

		public ServiceTypesController(IDatabase database)
		{
			_database = database;
		}

		[HttpGet]
		public ActionResult<IEnumerable<ServiceType>> GetServiceTypes()
		{
			var serviceTypes = _database.GetServiceTypes();
			return Ok(serviceTypes);
		}

		[HttpGet("{identifier}")]
		public ActionResult<Service> GetServiceType(string identifier)
		{
			var serviceType = _database.GetServiceType(identifier);
			//return NotFound();
			//return BadRequest();
			return Ok(serviceType);
		}
	}
}
