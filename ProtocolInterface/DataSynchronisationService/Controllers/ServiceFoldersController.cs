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
			throw new NotImplementedException();
		}

		[HttpGet("{identifier}")]
		public ActionResult<Service> GetServiceFolder(string identifier)
		{
			throw new NotImplementedException();
		}
	}
}
