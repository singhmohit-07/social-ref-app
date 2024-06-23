
namespace SocialRefApp.Entities
{
	public class SubCategorySubsection
	{

        public int SubCategoryId { get; set; }

        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string? Description { get; set; }

        public string? Icon { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int CreatedBy { get; set; }

        public bool IsActive { get; set; }

        public required string SectionType { get; set; }

        public List<SubSectionSubSectionItem>? SubSectionsSubSectionItems { get; set; }

    }
}

