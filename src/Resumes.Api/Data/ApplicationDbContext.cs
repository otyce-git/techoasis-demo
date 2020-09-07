using Microsoft.EntityFrameworkCore;
using Resumes.Api.Models;

namespace Resumes.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Profile> Profiles { get; set; }
    }
}