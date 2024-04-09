namespace recruitment.Models
{
	public class JobListing
	{
		public int JobListingId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime ApplicationDeadline { get; set; }
		public int JobCategoryId { get; set; }
		public JobCategory JobCategory { get; set; }
        public int JobsId { get; set; }
        public Jobs Jobs { get; set; }
        public ICollection<UserApplication>? UserApplications { get; set; }
	}
}
