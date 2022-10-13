using HackerthonProject.Features.Requests.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HackerthonProject.Controllers
{
    public class AdvocatesController : BaseAPIController
    {

        [HttpGet("GetAllAdvocates")]
        public async Task<IActionResult> GetAllAdvocates()
        {
            return HandleResult(await Mediator.Send(new GetAllAdvocatesRequest { }));
        }

        [HttpGet ("GetAdvocateById")]
        public async Task<IActionResult> GetAdvocateById(int id)
        {
            return HandleResult(await Mediator.Send(new GetAdvocateByIdRequest(id)));
        }
    }
}
