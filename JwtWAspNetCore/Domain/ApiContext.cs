using Microsoft.EntityFrameworkCore;

namespace JwtWAspNetCore.Domain
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            :base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Socio> Socios { get; set; }
    }
}
