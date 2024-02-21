namespace JobSearch.Core.Entities
{
    public class SocialMediaCompany
    { 
        public int Id { get; set; }
        public int SocialMediaId { get; set; }
        public SocialMedia SocialMedia { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public string Username { get; set; }

    }
}
