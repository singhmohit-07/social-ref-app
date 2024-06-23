using System;
using System.Collections.Generic;

namespace SocialRefApp.Entities;

public partial class UserProfile
{
    public int ProfileId { get; set; }

    public string UserId { get; set; } = null!;

    public string ProfileHandle { get; set; } = null!;

    public string? ProfileDescription { get; set; }

    public string? Location { get; set; }

    public bool? IsLocationEnabled { get; set; }

    public DateTime? ProfileCreatedDate { get; set; }

    public DateTime? ProfileModifiedDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime? ProfileDeactivationDate { get; set; }
}
