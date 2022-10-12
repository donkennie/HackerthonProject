using HackerthonProject.Models;

namespace HackerthonProject.DTOs
{
    public record CompanyDTO : BaseDTO
    {
        public string? Name { get; init; }

        public string? Logo { get; init; }

        public string? Summary { get; init; }

        public ICollection<Advocate>? Advocates { get; init; }
    }
}
