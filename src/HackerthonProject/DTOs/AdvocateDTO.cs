using HackerthonProject.Models;

namespace HackerthonProject.DTOs
{
     public class AdvocateDTO
     {
         public int Id { get; set; }

         public string Name { get; set; }

         public string Profile_pic { get; set; }

         public string Short_bio { get; set; }

         public string Long_bio { get; set; }

         public int Advocate_years_exp { get; set; }

         public CompanyForAdvocateDTO Company { get; set; }

         public ICollection<LinkDTO> Links { get; set; } = new List<LinkDTO>();

     }
}
