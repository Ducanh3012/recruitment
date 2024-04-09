namespace recruitment.Models
{
	public class UserApplication
	{
		public int UserApplicationId { get; set; }
		public int UserId { get; set; }
		public int JobListingId { get; set; }
		public int ApplicationStatusId { get; set; }
		public User User { get; set; }
		public JobListing JobListing { get; set; }
		public ApplicationStatus ApplicationStatus { get; set; }
	}
}
