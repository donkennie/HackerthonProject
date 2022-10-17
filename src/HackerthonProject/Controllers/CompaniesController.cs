using HackerthonProject.Core;
using HackerthonProject.DTOs;
using HackerthonProject.Features.Requests.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HackerthonProject.Controllers
{
    public class CompaniesController : BaseAPIController
    {

        [HttpGet("GetCompanyById")]
        [ProducesResponseType(typeof(AdvocateDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            return HandleResult(await Mediator.Send(new GetCompanyByIdRequest(id)));
        }

        [HttpGet("GetAllCompanies")]
        [ProducesResponseType(typeof(CompanyDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllCompanies()
        {
            return HandleResult(await Mediator.Send(new GetAllCompaniesRequest()));
        }
    }
}
