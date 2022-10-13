using HackerthonProject.Core;
using HackerthonProject.DTOs;
using MediatR;

namespace HackerthonProject.Features.Requests.Queries
{
    public sealed record GetAllAdvocatesRequest(): IRequest<ResultResponse<List<AdvocateDTO>>>;
 
}
