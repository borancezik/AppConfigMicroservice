using AppConfigMicroservice.Features.Config.Models;
using Microsoft.EntityFrameworkCore;

namespace AppConfigMicroservice.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<ConfigEntity> configs { get; set; }
    }
}
