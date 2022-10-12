using HackerthonProject.Models;

namespace HackerthonProject.DTOs
{
    public record CompanyDTO(string Name, string Logo, string Summary, ICollection<Advocate> Advocates);

}
