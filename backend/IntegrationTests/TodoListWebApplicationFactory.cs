namespace IntegrationTests
{
    using DbContext;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    internal class TodoListWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<TodoListDbContext>));

                var connString = GetConnectionString();
                services.AddDbContext<TodoListDbContext>(options => options.UseSqlServer(connString));

                var dbContext = CreateDbContext(services);
                dbContext.Database.EnsureCreated();
            });
        }

        private static string? GetConnectionString()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<TodoListWebApplicationFactory>()
                .Build();

            return configuration.GetConnectionString("TodoListConnection");
        }

        private static TodoListDbContext CreateDbContext(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var scope = serviceProvider.CreateScope();
            
            return scope.ServiceProvider.GetRequiredService<TodoListDbContext>();
        }
    }
}
