namespace SocialRefApp.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder applicationBuilder){
      
        using IServiceScope scope =applicationBuilder.ApplicationServices.CreateScope();
        
        using DataContext context = scope.ServiceProvider.GetRequiredService<DataContext>();

        context.Database.Migrate();

    }

}
