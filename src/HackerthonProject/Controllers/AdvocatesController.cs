using HackerthonProject.Core;
using HackerthonProject.DTOs;
using HackerthonProject.Features.Requests.Queries;
using HackerthonProject.RequestFeatures;
using Microsoft.AspNetCore.Mvc;

namespace HackerthonProject.Controllers
{
    public class AdvocatesController : BaseAPIController
    {

        [HttpGet("GetAllAdvocates")]
        [ProducesResponseType(typeof(AdvocateDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAdvocates([FromQuery] AdvocateParam advocateParam)
        {
            return HandlePagedResult(await Mediator.Send(new GetAllAdvocatesRequest { AdvocateParam = advocateParam}));
        }

        [HttpGet ("GetAdvocateById")]
        [ProducesResponseType(typeof(AdvocateDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAdvocateById(int id)
        {
            return HandleResult(await Mediator.Send(new GetAdvocateByIdRequest(id)));
        }
    }
}
