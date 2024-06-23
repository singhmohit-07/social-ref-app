namespace SocialRefApp;

public class UserProfileAddDto
{
    public string ProfileHandle { get; set; } = null!;

    public string? ProfileDescription { get; set; }

    public string? Location { get; set; }

    public bool? IsLocationEnabled { get; set; }

    
}
