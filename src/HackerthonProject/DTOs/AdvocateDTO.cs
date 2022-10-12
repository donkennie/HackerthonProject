using HackerthonProject.Models;

namespace HackerthonProject.DTOs
{
    public record AdvocateDTO(
        string? Name, string? Short_bio, string? Long_bio, 
        string? Profile_pic, int Advocate_years_exp, Company? Company, 
        ICollection<Links>? Links
    );
    
}
