namespace recruitment.Models
{
    public class Jobs
    {
        public int JobsId { get; set; }
        public ICollection<JobCategory>? JobsCategory { get; set; }
        public ICollection<JobListing>? Jobslisting { get; set; }

        public string Profile { get; set;}

        public int UserId { get; set; }
        public User? User {  get; set; }
    }
    }
