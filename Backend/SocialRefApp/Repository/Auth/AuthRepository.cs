using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using SocialRefApp.Data;
using SocialRefApp.Entities;
using SocialRefApp.Models;
using SocialRefApp.Services.EmailService;

namespace SocialRefApp.Repository.Auth
{
    public class AuthRepository : IAuthRepository
    {

        private readonly IConfiguration _configuration;

        private readonly DataContext _dataContext;

        private readonly IEmailService _emailService;

        public AuthRepository(DataContext dataContext, IConfiguration configuration, IEmailService emailService)
        {
            _configuration = configuration;
            _dataContext = dataContext;
            _emailService = emailService;
        }

        // public async Task<ServiceResponse<string>> Login(string emailAddress, string password)
        // {

        //     ServiceResponse<string> serviceResponse = new();

        //     try
        //     {

        //         User? user = await _dataContext.Users.FirstOrDefaultAsync(u => u.EmailAddress.ToLower().Equals(emailAddress.ToLower()));

        //         if (user is null)
        //         {
        //             throw new Exception("Account does not exist");
        //         }
        //         else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        //         {
        //             throw new Exception("Email address and passwords did not match");
        //         }
        //         else
        //         {
        //             serviceResponse.Data = CreateToken(user);
        //         }

        //         return serviceResponse;

        //     }
        //     catch (Exception ex)
        //     {

        //         serviceResponse.Message = ex.Message;

        //         serviceResponse.Success = false;

        //         return serviceResponse;

        //     }

        // }

        // public async Task<ServiceResponse<string>> Register(User user, string password)
        // {
        //     ServiceResponse<string> serviceResponse = new();

        //     try
        //     {

        //         if (await UserExistsInternal(user.EmailAddress.ToLower()))
        //         {
        //             throw new Exception("Account already exists");
        //         }

        //         CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

        //         user.PasswordHash = passwordHash;
        //         user.PasswordSalt = passwordSalt;
        //         user.EmailAddress = user.EmailAddress.ToLower();
        //         _dataContext.Add(user);
        //         await _dataContext.SaveChangesAsync();

        //         await _emailService.SendWelcomeEmailAsync(user.EmailAddress);

        //         User? userFinal = await _dataContext.Users.FirstOrDefaultAsync(u => u.UserId.Equals(user.UserId));

        //         serviceResponse.Data = CreateToken(user);
        //         serviceResponse.Message = "Account created";

        //         return serviceResponse;
        //     }
        //     catch (Exception ex)
        //     {
        //         serviceResponse.Success = false;
        //         serviceResponse.Message = ex.Message;

        //         return serviceResponse;
        //     }
        // }

        // public async Task<bool> UserExistsInternal(string emailAddress)
        // {
        //     if (await _dataContext.Users.AnyAsync(u => u.EmailAddress.ToLower() == emailAddress.ToLower()))
        //     {
        //         return true;
        //     }

        //     return false;
        // }

        // private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        // {
        //     using (var hmac = new System.Security.Cryptography.HMACSHA512())
        //     {
        //         passwordSalt = hmac.Key;
        //         passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //     }
        // }

        // private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        // {
        //     using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        //     {
        //         var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        //         return computedHash.SequenceEqual(passwordHash);

        //     }


        // }

        // async Task<ServiceResponse<bool>> IAuthRepository.UserExists(string emailAddress)
        // {
        //     ServiceResponse<bool> serviceResponse = new();

        //     if (await _dataContext.Users.AnyAsync(u => u.EmailAddress.ToLower() == emailAddress.ToLower()))
        //     {
        //         serviceResponse.Data = true;
        //         return serviceResponse;
        //     }

        //     serviceResponse.Message = "No user account found.";
        //     serviceResponse.Data = false;
        //     return serviceResponse;
        // }

        // private string CreateToken(User user)
        // {
        //     var claims = new List<Claim>
        //     {
        //         new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
        //         new Claim(ClaimTypes.Name,user.EmailAddress.ToString()),
        //     };

        //     var appSettingsToken = _configuration.GetSection("AppSettings:Token").Value;

        //     if (appSettingsToken is null)
        //     {
        //         throw new Exception("AppSettings token is null");
        //     }

        //     SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(appSettingsToken));

        //     SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        //     var tokenDescriptor = new SecurityTokenDescriptor
        //     {
        //         Subject = new ClaimsIdentity(claims),
        //         Expires = DateTime.Now.AddDays(1),
        //         SigningCredentials = creds
        //     };

        //     JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        //     SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);

        //     return tokenHandler.WriteToken(securityToken);
        // }

        // public async Task<ServiceResponse<bool>> ForgotPasswordRequest(string emailAddress)
        // {
        //     ServiceResponse<bool> serviceResponse = new();

        //     try
        //     {

        //         if (!await UserExistsInternal(emailAddress))
        //         {
        //             throw new Exception("Account does not exists.");
        //         }

        //         User? user = await _dataContext.Users.FirstOrDefaultAsync(u => u.EmailAddress.ToLower().Equals(emailAddress.ToLower()));

        //         if (user is null)
        //         {
        //             throw new Exception("Unable to get user account record.");
        //         }

        //         ForgotPassword forgotPassword = new ForgotPassword();

        //         forgotPassword.UserId = user.UserId;
        //         forgotPassword.RequestDateTime = DateTime.UtcNow;

        //         Random rnd1 = new Random(10); //seed value 10
        //         for (int j = 0; j < 4; j++)
        //         {
        //             Console.WriteLine(rnd1.Next());
        //         }

        //         string chars = "0123456789";
        //         Random? random = new Random();
        //         string? result = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());

        //         if (string.IsNullOrEmpty(result)) {
        //             throw new Exception("Invalid code generated");
        //         }

        //         CreatePasswordHash(result.ToString(), out byte[] codeHash, out byte[] codeSalt);

        //         forgotPassword.VerificationCodeSalt = codeSalt;

        //         forgotPassword.VerificationCodeHash = codeHash;

        //         _dataContext.Add<ForgotPassword>(forgotPassword);

        //         await _dataContext.SaveChangesAsync();

        //         #region Email User the OTP generated
        //         MailRequest mailRequest = new();
        //         mailRequest.ToEmail = emailAddress;
        //         mailRequest.Subject = "Request to change password";
        //         mailRequest.Body = $"<h1><b>Change Password Request</b></h1><br/><hr /><h2><b>Hi [EMAIL],</b></h2><br/><p style=\"font-size:16px\">The verification code for password change request is <b>[CODE]</b>.</p><br/><p style=\"font-size:16px\">Please enter this code in our portal to change your password.</p><br/><p style=\"font-size:16px\">Thank you.</p>".Replace("[EMAIL]",emailAddress).Replace("[CODE]",result);
        //         await _emailService.SendEmailAsync(mailRequest);
        //         #endregion

        //         serviceResponse.Data = true;
        //         serviceResponse.Message = "Forgot password request successfully created";
        //         return serviceResponse;
        //     }
        //     catch (Exception ex)
        //     {
        //         serviceResponse.Data = false;
        //         serviceResponse.Message = ex.Message;
        //         serviceResponse.Success = false;

        //         return serviceResponse;
        //     }

        // }

        // public async Task<ServiceResponse<bool>> ForgotPasswordCodeVerify(string emailAddress, string code)
        // {
        //     ServiceResponse<bool> serviceResponse = new();

        //     try
        //     {

        //         User? user = await _dataContext.Users.FirstOrDefaultAsync(u => u.EmailAddress.ToLower().Equals(emailAddress.ToLower())) ?? throw new Exception("Unable to get user account record.");
        //         ForgotPassword? forgotPassword = await _dataContext.ForgotPasswords.Where(f => f.UserId == user.UserId).OrderBy(f => f.RequestDateTime).Reverse().FirstOrDefaultAsync() ?? throw new Exception("Unable to get forgot password record.");

        //         ///TODO: Check if request is 1 hour old
        //         //if (forgotPassword.RequestDateTime.CompareTo(DateTime.UtcNow) == -1)
        //         //{
        //         //    throw new Exception("Request is expired.");
        //         //}

        //         if (!VerifyPasswordHash(code, forgotPassword.VerificationCodeHash, forgotPassword.VerificationCodeSalt))
        //         {
        //             throw new Exception("Invalid code entered");

        //         }

        //         forgotPassword.IsVerified = true;

        //         _dataContext.Update<ForgotPassword>(forgotPassword);

        //         await _dataContext.SaveChangesAsync();

        //         serviceResponse.Data = true;
        //         serviceResponse.Message = "Code verification successful";
        //         serviceResponse.Success = true;

        //         return serviceResponse;
        //     }
        //     catch (Exception ex)
        //     {
        //         serviceResponse.Data = false;

        //         serviceResponse.Message = ex.Message;
        //         serviceResponse.Success = false;

        //         return serviceResponse;
        //     }

        // }

        // public async Task<ServiceResponse<bool>> ForgotSetNewPassword(string emailAddress, string newPassword)
        // {
        //     ServiceResponse<bool> serviceResponse = new();

        //     try
        //     {

        //         User? user = await _dataContext.Users.FirstOrDefaultAsync(u => u.EmailAddress.ToLower().Equals(emailAddress.ToLower()));

        //         if (user is null)
        //         {
        //             throw new Exception("Unable to get user account record.");
        //         }

        //         ForgotPassword? forgotPassword = await _dataContext.ForgotPasswords.Where(f => f.UserId == user.UserId).OrderBy(f => f.RequestDateTime).Reverse().FirstOrDefaultAsync();

        //         if (forgotPassword is null)
        //         {
        //             throw new Exception("Unable to get forgot password record.");
        //         }

        //         if (!forgotPassword.IsVerified)
        //         {
        //             throw new Exception("Unverified record.");

        //         }

        //         CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);

        //         user.PasswordHash = passwordHash;
        //         user.PasswordSalt = passwordSalt;

        //         _dataContext.Update(user);

        //         await _dataContext.SaveChangesAsync();

        //         #region Email User about password change
        //         MailRequest mailRequest = new();
        //         mailRequest.ToEmail = emailAddress;
        //         mailRequest.Subject = "Login Password Changed";
        //         mailRequest.Body = $"<h1><strong>Password Changed</strong></h1>\n\n<p>&nbsp;</p>\n\n<hr />\n<h2><strong>Hi [EMAIL],</strong></h2>\n\n<p><span style=\"font-size:16px\">The new password you requested is set successfully.</span></p>\n\n<p><span style=\"font-size:16px\">You can use this new password to login.</span></p>\n\n<p><span style=\"font-size:16px\">Thank you.&nbsp;</span></p>\n".Replace("[EMAIL]",emailAddress);
        //         await _emailService.SendEmailAsync(mailRequest);
        //         #endregion

        //         serviceResponse.Data = true;
        //         serviceResponse.Message = "Password changed";

        //         return serviceResponse;
        //     }
        //     catch (Exception ex)
        //     {
        //         serviceResponse.Message = ex.Message;
        //         serviceResponse.Success = false;

        //         return serviceResponse;
        //     }

        // }

    }
}

