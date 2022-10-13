using AutoMapper;
using HackerthonProject.Core;
using HackerthonProject.DTOs;
using HackerthonProject.Features.Requests.Queries;
using HackerthonProject.Repositories.Abstraction;
using MediatR;

namespace HackerthonProject.Features.Handlers.Queries
{
    public sealed record GetCompanyByIdRequestHandler : IRequestHandler<GetCompanyByIdRequest, ResultResponse<CompanyDTO>>
    {
        private readonly ICompanyRepository _companyRepository;

        private readonly IMapper _mapper;

        public GetCompanyByIdRequestHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;        
        }

        public async Task<ResultResponse<CompanyDTO>> Handle(GetCompanyByIdRequest request, CancellationToken cancellationToken)
        {
            var query = await _companyRepository.GetCompanyById(request.id);

            if (query is null)
            {
                return ResultResponse<CompanyDTO>.Failure("Not Found");
            }

            var response = _mapper.Map<CompanyDTO>(query);

            return ResultResponse<CompanyDTO>.Success(response);
        }
    }

}
