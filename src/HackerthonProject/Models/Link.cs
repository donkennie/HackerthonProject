using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackerthonProject.Models
{   
    public class Link 
    {
        [Column("LinkId")]
        public int Id { get; set; }

        public string Youtube { get; set; }

        public string Twitter { get; set; }

        public string Github { get; set; }

        [ForeignKey("AdvocateId")]
        public int AdvocateId { get; set; }

    }
}
