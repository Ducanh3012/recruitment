namespace recruitment.Models
{
	public class CV
	{
		public int CVId { get; set; }
		public string Experience { get; set; }
		public string Specialization { get; set; }
		public string SelfDescription { get; set; }
		public int UserId { get; set; }
		public User User { get; set; }
	}
}
