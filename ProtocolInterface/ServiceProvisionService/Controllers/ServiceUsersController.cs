using Microsoft.AspNetCore.Mvc;
using ServiceProvisionService.Data;
using ServiceProvisionService.Models;

namespace ServiceProvisionService.Controllers
{
	[Route("api/serviceusers")]
	[ApiController]
	public class ServiceUsersController: ControllerBase
	{
		private readonly IDatabase _database;

		public ServiceUsersController(IDatabase database)
		{
			_database = database;
		}

		// GET api/serviceusers/GetServiceUsers
		[HttpGet]
		public ActionResult<IEnumerable<ServiceUser>> GetServiceUsers()
		{
			try
			{
				var serviceUsers = _database.GetServiceUsers();

				return Ok(serviceUsers);
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

		// GET api/serviceusers/GetServiceUser?identifier=abc
		[HttpGet("{identifier}")]
		public ActionResult<ServiceUser> GetServiceUser(string identifier)
		{
			var serviceUser = _database.GetServiceUser(identifier);

			return Ok(serviceUser);
		}

	}
}
