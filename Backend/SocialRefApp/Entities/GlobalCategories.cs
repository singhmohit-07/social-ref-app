
namespace SocialRefApp.Entities
{
	public class GlobalCategories
	{

		public int Id { get; set; }

		public string Name { get; set; } = "";

		public string Description { get; set; } = "";

		public string Icon { get; set; } = "0xe0ef";

		public DateTime CreatedDate { get; set; }

		public DateTime? ModifiedDate { get; set; }

		public bool IsActive { get; set; }
	}
}
