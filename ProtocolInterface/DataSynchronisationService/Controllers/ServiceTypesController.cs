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
			throw new NotImplementedException();
		}

		[HttpGet("{identifier}")]
		public ActionResult<Service> GetServiceType(string identifier)
		{
			throw new NotImplementedException();
		}
	}
}
