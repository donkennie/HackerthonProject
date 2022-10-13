using HackerthonProject.Core;
using HackerthonProject.DTOs;
using MediatR;

namespace HackerthonProject.Features.Requests.Queries
{
    public sealed record GetCompanyByIdRequest(int id):IRequest<ResultResponse<CompanyDTO>>;

}
