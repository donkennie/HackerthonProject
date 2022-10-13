using System.ComponentModel.DataAnnotations.Schema;

namespace HackerthonProject.Models
{
    public class Links 
    {
        [Column("LinkId")]
        public int Id { get; set; }

        public string Youtube { get; set; }

        public string Twitter { get; set; }

        public string Github { get; set; }
    }
}
