
/*using ApiNotes.Context;
using ApiNotes.Entities;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ApiNotes.Config
{
    public class TestDataSeeder : IHostedService
    {

        private readonly IServiceProvider _serviceProvider;
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope()) {

                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                // Clear existing data
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                User u1 = new User() { };
                //var l1 = new Login(null);
                // Save changes
                await context.SaveChangesAsync();

            }
        }
        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}*/
