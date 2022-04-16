using Microsoft.AspNetCore.Mvc;

using DataSynchronisationService.Data;
using DataSynchronisationService.Models;

namespace DataSynchronisationService.Controllers
{
	[Route("api/reasonforenddates")]
	[ApiController]
	public class ReasonForEndDatesController : ControllerBase
	{
		private readonly IDatabase _database;

		public ReasonForEndDatesController(IDatabase database)
		{
			_database = database;
		}

		[HttpGet]
		public ActionResult<IEnumerable<ReasonForEndDate>> GetReasonForEndDates()
		{
			string errorMessage;

			var reasonForEndDates = _database.GetReasonForEndDates(out errorMessage, null);

			if (errorMessage != string.Empty)
				return BadRequest(errorMessage);
			else
				return Ok(reasonForEndDates);
		}

		[HttpGet("{identifier}")]
		public ActionResult<ReasonForEndDate> GetReasonForEndDate(string identifier)
		{
			string errorMessage;
			int parsedIdentifier;

			if (!int.TryParse(identifier, out parsedIdentifier))
				return NotFound();

			var e = _database.GetReasonForEndDates(out errorMessage, parsedIdentifier);

			if (errorMessage != string.Empty)
				return BadRequest(errorMessage);
			else if (e.Count<ReasonForEndDate>() == 0)
				return NotFound();
			else
				return Ok(e.First<ReasonForEndDate>());
		}
	}
}
