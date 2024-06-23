using System;
namespace SocialRefApp.Dtos.Vacancy
{
	public class VacancyUpdateRequestDto
    {
        public int Id { get; set; }

        public string Heading { get; set; } = "";

        public string? SubHeading { get; set; }

        public string? Content { get; set; }

        public string? MainImage { get; set; }

        public string? ContentImages { get; set; }

        public string? Category { get; set; }

        public string? Tags { get; set; }

        public string? References { get; set; }

        public string? YoutubeLink { get; set; }

        public string? YoutubeTitle { get; set; }

        public bool? YoutubeEnable { get; set; }

        public string? Status { get; set; }

        public DateTime? OpenedDate { get; set; }

        public DateTime? ClosedDate { get; set; }
    }
}

