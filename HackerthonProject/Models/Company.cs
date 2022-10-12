namespace HackerthonProject.Models
{
    public class Company : BaseDomainEntity
    {
        public string? Name { get; set; }

        public string? Logo { get; set; }

        public string? Summary { get; set; }

        public ICollection<Advocate>? Advocates { get; set; }
    }
}
