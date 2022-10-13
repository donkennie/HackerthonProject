using AutoMapper;
using HackerthonProject.Core;
using HackerthonProject.DTOs;
using HackerthonProject.Features.Requests.Queries;
using HackerthonProject.Repositories.Abstraction;
using MediatR;

namespace HackerthonProject.Features.Handlers.Queries
{
    public sealed record GetAllAdvocatesRequestHandler : IRequestHandler<GetAllAdvocatesRequest, ResultResponse<List<AdvocateDTO>>>
    {
        private readonly IAdvocateRepository _advocateRepository;
        private readonly IMapper _mapper;

        public GetAllAdvocatesRequestHandler(IAdvocateRepository advocateRepository, IMapper mapper)
        {
            _advocateRepository = advocateRepository;
            _mapper = mapper;
        }

        public async Task<ResultResponse<List<AdvocateDTO>>> Handle(GetAllAdvocatesRequest request, CancellationToken cancellationToken)
        {
            var query = await _advocateRepository.GetAllAdvocates();
            if (query is null)
            {
                return ResultResponse<List<AdvocateDTO>>.Failure("Not Found");
            }

            var response = _mapper.Map<List<AdvocateDTO>>(query);

            return ResultResponse<List<AdvocateDTO>>.Success(response);
        }
    }
}
