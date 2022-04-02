using Microsoft.AspNetCore.Mvc;
using ServiceProvisionService.Data;
using ServiceProvisionService.Models;

namespace ServiceProvisionService.Controllers
{
	[Route("api/clientgroups")]
	[ApiController]
	public class ClientGroupsController: ControllerBase
	{
		private readonly IDatabase _database;

		public ClientGroupsController(IDatabase database)
		{
			_database = database;
		}

		[HttpGet]
		public ActionResult<IEnumerable<ClientGroup>> GetClientGroups()
		{
			try
			{
				var clientGroups = _database.GetClientGroups();

				return Ok(clientGroups);
			}
			catch (ArgumentException ex)
			{
				return NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest();
			}
			finally
			{ }
		}

		[HttpGet("{identifier}")]
		public ActionResult<ClientGroup> GetClientGroup(string identifier)
		{
			var clientGroup = _database.GetClientGroup(identifier);

			return Ok(clientGroup);
		}
	}
}
