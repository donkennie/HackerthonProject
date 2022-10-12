using HackerthonProject.Models;

namespace HackerthonProject.DTOs
{
    public record AdvocateDTO : BaseDTO
    {
        public string? Name { get; init; }

        public string? Short_bio { get; init; }

        public string? Long_bio { get; init; }

        public string? Profile_pic { get; init; }

        public int Advocate_years_exp { get; init; }

        public Company? Company { get; init; }

        public ICollection<Links>? Links { get; init; }
    }
}
