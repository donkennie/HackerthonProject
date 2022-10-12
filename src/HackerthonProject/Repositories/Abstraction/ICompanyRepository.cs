using HackerthonProject.Core;
using HackerthonProject.DTOs;
using HackerthonProject.Models;

namespace HackerthonProject.Repositories.Abstraction
{
    public interface ICompanyRepository
    {

        Task<List<Company>> GetAllCompanies();

        Task<Company> GetCompanyById(int id);
    }
}
