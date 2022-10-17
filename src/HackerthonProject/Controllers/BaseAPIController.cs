using HackerthonProject.Core;
using HackerthonProject.Extensions;
using HackerthonProject.RequestFeatures;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HackerthonProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseAPIController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult HandleResult<T> (ResultResponse<T> result)
        {
            if (result is null)
            {
                return NotFound();
            }

            if(result.IsSuccess && result.Value != null)
            {
                return Ok(result.Value);
            }

            if (result.IsSuccess && result.Value is null)
            {
                return NotFound();
            }

            return BadRequest(result.Error);
        }


        protected ActionResult HandlePagedResult<T>(ResultResponse<PagedList<T>> result)
        {
            if (result == null) return NotFound();
            if (result.IsSuccess && result.Value != null)
            {
                Response.AddPaginationHeader(result.Value.MetaData.CurrentPage, result.Value.MetaData.PageSize,
                    result.Value.MetaData.TotalCount, result.Value.MetaData.TotalPages);

                return Ok(result.Value);
            }
            if (result.IsSuccess && result.Value == null)
                return NotFound();
            return BadRequest(result.Error);
        }
    }
}
