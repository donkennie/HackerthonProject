using HackerthonProject.Models;

namespace HackerthonProject.Repositories.Abstraction
{
    public interface IAdvocateRepository
    {
        Task<List<Advocate>> GetAllAdvocates();

        Task<Advocate> GetAdvocateById(int id);
    }
}
