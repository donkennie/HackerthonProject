using HackerthonProject.Models;

namespace HackerthonProject.DTOs
{
    public record AdvocateDTO( int id,
        string Name, string Profile_pic, string Short_bio, string Long_bio, 
         int Advocate_years_exp, CompanyForAdvocateDTO Company ,
        ICollection<LinkDTO> Links
    );
    
}
