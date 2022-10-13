using AutoMapper;
using HackerthonProject.Core;
using HackerthonProject.DTOs;
using HackerthonProject.Features.Requests.Queries;
using HackerthonProject.Repositories.Abstraction;
using MediatR;

namespace HackerthonProject.Features.Handlers.Queries
{
    public sealed record GetAdvocateByIdRequestHandler : IRequestHandler<GetAdvocateByIdRequest, ResultResponse<AdvocateDTO>>
    {
        private readonly IAdvocateRepository _advocateRepository;

        private readonly IMapper _mapper;

        public GetAdvocateByIdRequestHandler(IAdvocateRepository advocateRepository, IMapper mapper)
        {
            _advocateRepository = advocateRepository;
            _mapper = mapper;
        }

        public async Task<ResultResponse<AdvocateDTO>> Handle(GetAdvocateByIdRequest request, CancellationToken cancellationToken)
        {
            var query = await _advocateRepository.GetAdvocateById(request.id);

            if (query is null)
            {
               return ResultResponse<AdvocateDTO>.Failure("Not Found");
            }

            var response = _mapper.Map<AdvocateDTO>(query);

            return ResultResponse<AdvocateDTO>.Success(response);
        }
    }
}
