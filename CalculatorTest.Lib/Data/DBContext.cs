using System.Threading.Tasks;
using GLEducation.Lib.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GLEducation.Lib.Data
{
    public class LogDBContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public LogDBContext(DbContextOptions<LogDBContext> options,IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("GLEduLogDataDB"));
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogData>().HasKey(t => t.Id);
        }
        
        public DbSet<LogData> LogDatas { get; set; }
        
    }
}