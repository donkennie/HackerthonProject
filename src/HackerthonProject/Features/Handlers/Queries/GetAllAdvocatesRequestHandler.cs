using AutoMapper;
using AutoMapper.QueryableExtensions;
using HackerthonProject.Core;
using HackerthonProject.Data;
using HackerthonProject.DTOs;
using HackerthonProject.Features.Requests.Queries;
using HackerthonProject.Repositories.Abstraction;
using HackerthonProject.RequestFeatures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

namespace HackerthonProject.Features.Handlers.Queries
{
    public sealed record GetAllAdvocatesRequestHandler : IRequestHandler<GetAllAdvocatesRequest, ResultResponse<PagedList<AdvocateDTO>>>
    {
        private readonly IAdvocateRepository _advocateRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _applicationDbContext;

        public GetAllAdvocatesRequestHandler(IAdvocateRepository advocateRepository, IMapper mapper, ApplicationDbContext applicationDbContext)
        {
            _advocateRepository = advocateRepository;
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ResultResponse<PagedList<AdvocateDTO>>> Handle(GetAllAdvocatesRequest request, CancellationToken cancellationToken)
        {
            //  var query = await _advocateRepository.GetAllAdvocates();
            var query =  _applicationDbContext.Advocates?
            //    .Where(i => request.AdvocateParam.SearchTerm == "" || i.Name.Contains(request.AdvocateParam.SearchTerm))
                .OrderBy(i => i.Id)
              .ProjectTo<AdvocateDTO>(_mapper.ConfigurationProvider)
               .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.AdvocateParam.SearchTerm))
            {
                query = query.Search(request.AdvocateParam.SearchTerm);
            }

            if (query is null)
            {
                return ResultResponse<PagedList<AdvocateDTO>>.Failure("Not Found");
            }

          //  var response = _mapper.Map<PagedList<AdvocateDTO>>(query);

            return ResultResponse<PagedList<AdvocateDTO>>.Success(await PagedList<AdvocateDTO>.CreateAsync(query, request.AdvocateParam.PageNumber, request.AdvocateParam.PageSize));
        }
    }
}


