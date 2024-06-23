using System;
namespace SocialRefApp.Models
{
	public class MailRequest
	{
      
            required public string ToEmail { get; set; }
            required public string Subject { get; set; }
            required public string Body { get; set; }
            public List<IFormFile>? Attachments { get; set; }
    }
}

