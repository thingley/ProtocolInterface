using Microsoft.AspNetCore.Mvc;

using DataSynchronisationService.Data;
using DataSynchronisationService.Models;

namespace DataSynchronisationService.Controllers
{
	[Route("api/servicefolders")]
	[ApiController]
	public class ServiceFoldersController : ControllerBase
	{
		private readonly IDatabase _database;

		public ServiceFoldersController(IDatabase database)
		{
			_database = database;
		}

		[HttpGet]
		public ActionResult<IEnumerable<ServiceFolder>> GetServiceFolders()
		{
			var serviceFolders = _database.GetServiceFolders();
			return Ok(serviceFolders);
		}

		[HttpGet("{identifier}")]
		public ActionResult<Service> GetServiceFolder(string identifier)
		{
			var serviceFolder = _database.GetServiceFolder(identifier);
			//return NotFound();
			//return BadRequest();
			return Ok(serviceFolder);
		}
	}
}
