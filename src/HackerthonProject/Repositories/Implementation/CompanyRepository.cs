using HackerthonProject.Data;
using HackerthonProject.DTOs;
using HackerthonProject.Models;
using HackerthonProject.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace HackerthonProject.Repositories.Implementation
{
    internal sealed class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CompanyRepository(ApplicationDbContext applicationDbContext) => _applicationDbContext = applicationDbContext;


        public async Task<List<Company>> GetAllCompanies() => 
                  await _applicationDbContext.Companies
                   .Include(p => p.Advocates).ThenInclude(o => o.Links)
                   .ToListAsync();


        public async Task<Company> GetCompanyById(int id) =>
            await _applicationDbContext.Companies
            .Include(p => p.Advocates).ThenInclude(o => o.Links)
            .FirstOrDefaultAsync(i => i.Id == id);

    }
}
