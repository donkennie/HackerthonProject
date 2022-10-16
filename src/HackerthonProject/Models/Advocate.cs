﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HackerthonProject.Models
{
    public class Advocate 
    {
        [Column("AdvocateId")]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Short_bio { get; set; }

        public string Long_bio { get; set; }

        public string Profile_pic { get; set; }

        public int Advocate_years_exp { get; set; }

        [ForeignKey(nameof(Company))]
        public int CompanyId { get; set; }

        public Company Company { get; set; }

      /* [ForeignKey(nameof(Links))]
        public int LinkId { get; set; }*/

        public virtual ICollection<Link> Links { get; set; } = new List<Link>();

       /* public Advocate()
        {
           // this.Links = new List<Link>();
        }*/

        


    }
}
