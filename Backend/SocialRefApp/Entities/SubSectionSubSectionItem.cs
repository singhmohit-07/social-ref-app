
namespace SocialRefApp.Entities
{
	public class SubSectionSubSectionItem

    {
		public int Id { get; set; }

        public int SubSectionsItemId { get; set; }

        public required SubSectionItem SubSectionItem { get; set; }

        public int SubCategorySubSectionId { get; set; }

        public required SubCategorySubsection SubCategorySubSection { get; set; }

    }
}

