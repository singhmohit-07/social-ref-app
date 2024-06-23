
namespace SocialRefApp.Entities
{
	public class GlobalCategorySubCategories
	{
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string? Description { get; set; }

        public string? Icon { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int CategoryId { get; set; }

        public bool IsActive { get; set; }

        public List<SubCategorySubsection>? SubCategorySubsections { get; set; }

    }
}

