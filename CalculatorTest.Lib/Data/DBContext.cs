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
            var conString = _configuration.GetConnectionString("GLEduLogDataDB");
            
            options.UseSqlServer(_configuration.GetConnectionString("GLEduLogDataDB"));
        }
        
        public DbSet<LogData> LogDatas { get; set; }
        
    }
}