using HackerthonProject.Features.Requests.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HackerthonProject.Controllers
{
    public class CompaniesController : BaseAPIController
    {

        [HttpGet("GetCompanyById")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            return HandleResult(await Mediator.Send(new GetCompanyByIdRequest(id)));
        }

        [HttpGet("GetAllCompanies")]
        public async Task<IActionResult> GetAllCompanies()
        {
            return HandleResult(await Mediator.Send(new GetAllCompaniesRequest()));
        }
    }
}
