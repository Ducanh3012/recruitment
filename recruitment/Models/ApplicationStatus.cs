namespace recruitment.Models
{
	public class ApplicationStatus
	{
		public int ApplicationStatusId { get; set; }
		public string StatusName { get; set; }
		public ICollection<UserApplication> UserApplications { get; set; }
	}
}
