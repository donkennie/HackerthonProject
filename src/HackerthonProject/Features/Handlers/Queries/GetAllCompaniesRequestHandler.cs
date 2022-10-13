using AutoMapper;
using HackerthonProject.Core;
using HackerthonProject.DTOs;
using HackerthonProject.Features.Requests.Queries;
using HackerthonProject.Repositories.Abstraction;
using MediatR;

namespace HackerthonProject.Features.Handlers.Queries
{
    public sealed record GetAllCompaniesRequestHandler : IRequestHandler<GetAllCompaniesRequest, ResultResponse<List<CompanyDTO>>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetAllCompaniesRequestHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<ResultResponse<List<CompanyDTO>>> Handle(GetAllCompaniesRequest request, CancellationToken cancellationToken)
        {
            var query = await _companyRepository.GetAllCompanies();

            if (query is null)
            {
                return ResultResponse<List<CompanyDTO>>.Failure("Not Found");
            }

            var response = _mapper.Map<List<CompanyDTO>>(query);

            return ResultResponse<List<CompanyDTO>>.Success(response);
        }
    }
}
