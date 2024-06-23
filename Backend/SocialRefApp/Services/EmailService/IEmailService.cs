using System;
using SocialRefApp.Models;

namespace SocialRefApp.Services.EmailService
{
	public interface IEmailService
	{

        Task SendEmailAsync(MailRequest mailRequest);

        Task SendWelcomeEmailAsync(string emailAddress);

    }
}

