
namespace SocialRefApp.Entities
{
	public class SubSectionItem
    {

        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public string? AdditionalNote { get; set; }

        public int SerialNumber { get; set; }

        public int? PartNumber { get; set; }

        public int? TotalParts { get; set; }

        public string? Icon { get; set; }

        public string? Image { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; } = DateTime.Now;

        public int CreatedBy { get; set; }

        public bool IsActive { get; set; } = true;

        public required string ListItemType { get; set; }

        public string? NavigationReference { get; set; }

        public List<SubSectionSubSectionItem>? SubSectionsSubSectionItems { get; set; }

    }
}

