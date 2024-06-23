using System;
namespace SocialRefApp.Dtos.CurrentAffairs
{
    public class CurrentAffairsGetResponseDto
    {
        public int Id { get; set; }

        public string Heading { get; set; } = "";

        public string? SubHeading { get; set; } = "";

        public string? Content { get; set; } = "";

        public string? MainImage { get; set; } = "";

        public string? ContentImages { get; set; } = "";

        public string? Tags { get; set; } = "";

        public string? References { get; set; } = "";

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public string? CreatedByName { get; set; } = "";

        public bool IsActive { get; set; } = true;

        public string? YoutubeLink { get; set; } = "";

        public string? YoutubeTitle { get; set; } = "";

        public bool? YoutubeEnable { get; set; } = false;

        public string? Html { get; set; }


    }
}

