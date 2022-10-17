using HackerthonProject.Core;
using HackerthonProject.DTOs;
using HackerthonProject.RequestFeatures;
using MediatR;

namespace HackerthonProject.Features.Requests.Queries
{
    public sealed record GetAllAdvocatesRequest : IRequest<ResultResponse<PagedList<AdvocateDTO>>>
    {
        public AdvocateParam AdvocateParam { get; set; }    
    }
 
}
