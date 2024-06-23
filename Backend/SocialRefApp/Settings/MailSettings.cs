using System;
namespace SocialRefApp.Settings
{
	public class MailSettings
	{
        required public string Mail { get; set; }
        required public string DisplayName { get; set; }
        required public string Password { get; set; }
        required public string Host { get; set; }
        required public int Port { get; set; }
    }
}

