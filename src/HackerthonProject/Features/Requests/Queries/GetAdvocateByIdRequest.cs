using HackerthonProject.Core;
using HackerthonProject.DTOs;
using MediatR;

namespace HackerthonProject.Features.Requests.Queries
{
    public sealed record GetAdvocateByIdRequest(int id):IRequest<ResultResponse<AdvocateDTO>>;
    
}
