namespace recruitment.Models
{
	public class User
	{
		public int UserId { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public int RoleId { get; set; }
		public Role Role { get; set; }
		public ICollection<UserApplication> UserApplications { get; set; }
		public Profile Profile { get; set; }
		public CV CV { get; set; }
	}
}
