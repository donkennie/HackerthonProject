using HackerthonProject.Data;
using HackerthonProject.Models;
using HackerthonProject.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace HackerthonProject.Repositories.Implementation
{
    internal sealed class AdvocateRepository : IAdvocateRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AdvocateRepository(ApplicationDbContext applicationDbContext) => _applicationDbContext = applicationDbContext;

        public async Task<List<Advocate>> GetAllAdvocates() => await _applicationDbContext.Advocates
            .Include(l => l.Links).ToListAsync();


        public async Task<Advocate> GetAdvocateById(int id) => await _applicationDbContext.Advocates.FindAsync(id);


    }
}
