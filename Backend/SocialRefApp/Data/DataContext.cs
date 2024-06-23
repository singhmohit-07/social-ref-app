using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SocialRefApp.Entities;

namespace SocialRefApp.Data
{
    public class DataContext : IdentityDbContext<User>

	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("identity");

            // modelBuilder.Entity<User>().Property(u=>u.Initials).HasMaxLength(5);
            
            // modelBuilder.Entity<SubSectionSubSectionItem>()
            //     .HasOne(s => s.SubCategorySubSection).WithMany(si => si.SubSectionsSubSectionItems).HasForeignKey(sid => sid.SubCategorySubSectionId);

            // modelBuilder.Entity<SubSectionSubSectionItem>()
            //      .HasOne(s => s.SubSectionItem).WithMany(si => si.SubSectionsSubSectionItems).HasForeignKey(sid => sid.SubSectionsItemId);


        }

    //    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
    //options.UseSqlServer("DataSource = identityDb; Cache=Shared");

        // public DbSet<Student> Students => Set<Student>();
        // public DbSet<User> Users => Set<User>();
        // public DbSet<ForgotPassword> ForgotPasswords => Set<ForgotPassword>();
        // public DbSet<GlobalCategories> GlobalCategories => Set<GlobalCategories>();
        // public DbSet<GlobalCategorySubCategories> GlobalCategorySubCategories => Set<GlobalCategorySubCategories>();
        // public DbSet<SubCategorySubsection> SubCategorySubsections => Set<SubCategorySubsection>();
        // public DbSet<SubSectionItem> SubSectionItems => Set<SubSectionItem>();
        // public DbSet<SubSectionSubSectionItem> SubSectionsSubSectionItems => Set<SubSectionSubSectionItem>();
        // public DbSet<CurrentAffairs> CurrentAffairs => Set<CurrentAffairs>();
        // public DbSet<Vacancy> Vacancy => Set<Vacancy>();
        // public DbSet<Article> Articles => Set<Article>();

    }
}

