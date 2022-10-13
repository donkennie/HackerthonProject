﻿using HackerthonProject.Core;
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
    }
}
