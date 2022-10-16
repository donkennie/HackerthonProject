using HackerthonProject.Models;

namespace HackerthonProject.DTOs
{
    public record CompanyDTO(int id, string Name, string Logo, string Summary, ICollection<AdvocateDTO> Advocates);
}
