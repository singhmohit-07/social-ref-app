
namespace SocialRefApp.Entities
{
	public class ForgotPassword
	{
		public int Id { get; set; }

		public DateTime RequestDateTime { get; set; }

        public byte[]? VerificationCodeSalt { get; set; }

		public byte[]? VerificationCodeHash { get; set; }

		public bool IsVerified { get; set; }

		public int UserId { get; set; }
	}
}

