global using Microsoft.EntityFrameworkCore;
global using AutoMapper;

global using SocialRefApp.Data;
global using SocialRefApp.Services.StudentService;
global using SocialRefApp.Repository.Auth;
global using SocialRefApp.Repository.Metadata;
global using SocialRefApp.Services.CurrentAffairService;
global using SocialRefApp.Services.VacancyService;

using Microsoft.OpenApi.Models;
using MailKit;
using SocialRefApp.Settings;
using SocialRefApp.Services.EmailService;
using SocialRefApp.Services.ContentService;
using Microsoft.AspNetCore.Identity;
using SocialRefApp.Entities;
using SocialRefApp.Extensions;
using SocialRefApp.Services.ProfileService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.BearerToken;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<DataContext>( options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<SrDevDbContext>( options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    // c=>
    // {
    //     // c.SwaggerDoc("v1", new OpenApiInfo { Title = "SocialReferenceAppAPI", Version = "v1" });
    //     c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    //     {
    //         Description = """ Standard Authorization header using the Bearer scheme. Example "bearer {token}" """,
    //         In = ParameterLocation.Header,
    //         Name = "Authorization",
    //         Type = SecuritySchemeType.ApiKey
    //     });
    // }

    c=>{
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
        
        var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter your JWT token in this field",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    };

    c.AddSecurityDefinition("Bearer", securityScheme);

    var securityRequirement = new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    };

    c.AddSecurityRequirement(securityRequirement);
    }
    );

builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<DataContext>();

builder.Services.AddAuthorization();

// builder.Services.AddAuthentication(o=>{
//     o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
// })
// .AddBearerToken(IdentityConstants.BearerScheme)
// .AddJwtBearer();

// .AddCookie(IdentityConstants.ApplicationScheme)
// .AddGoogle(options =>
//    {
//        IConfigurationSection googleAuthNSection =
//        builder.Configuration.GetSection("Authentication:Google");
//        options.ClientId = googleAuthNSection["ClientId"]!;
//        options.ClientSecret = googleAuthNSection["ClientSecret"]!;
//    });
//    .AddFacebook(options =>
//    {
//        IConfigurationSection FBAuthNSection =
//        configuration.GetSection("Authentication:FB");
//        options.ClientId = FBAuthNSection["ClientId"];
//        options.ClientSecret = FBAuthNSection["ClientSecret"];
//    })
//    .AddMicrosoftAccount(microsoftOptions =>
//    {
//        microsoftOptions.ClientId = configuration["Authentication:Microsoft:ClientId"];
//        microsoftOptions.ClientSecret = configuration["Authentication:Microsoft:ClientSecret"];
//    })
//    .AddTwitter(twitterOptions =>
//    {
//        twitterOptions.ConsumerKey = configuration["Authentication:Twitter:ConsumerAPIKey"];
//        twitterOptions.ConsumerSecret = configuration["Authentication:Twitter:ConsumerSecret"];
//        twitterOptions.RetrieveUserDetails = true;
//    });

builder.Services.AddIdentityCore<User>().AddEntityFrameworkStores<DataContext>().AddApiEndpoints();

builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IMetadataRepository, MetadataRepository>();
builder.Services.AddScoped<ICurrentAffairService, CurrentAffairService>();
builder.Services.AddScoped<IVacancyService, VacancyService>();
builder.Services.AddScoped<IContentService, ContentService>();

builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

if (app.Environment.IsDevelopment())
{
 app.ApplyMigrations();
}

app.MapIdentityApi<User>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

