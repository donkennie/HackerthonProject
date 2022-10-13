using System.ComponentModel.DataAnnotations.Schema;

namespace HackerthonProject.Models
{
    public class Company 
    {
        [Column("CompanyId")]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Logo { get; set; }

        public string Summary { get; set; }

        public ICollection<Advocate> Advocates { get; set; }
    }
}
