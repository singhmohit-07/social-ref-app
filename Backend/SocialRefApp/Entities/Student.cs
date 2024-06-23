
namespace SocialRefApp.Entities
{
    public class Student
    {

        public int StudentId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? Age { get; set; }

        public DateTime? DateOfEnroll { get; set; }

        public string? SubCategorySelected { get; set; }

        public DateTime? DateModified { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }

        public bool EmailNewsletterPreference { get; set; } = true;

    }

}

