namespace Resumes.Api.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Website { get; set; }
        public string PhotoUrl { get; set; }
    }
}