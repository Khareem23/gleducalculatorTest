using System.Threading.Tasks;
using GLEducation.Lib.Entities;

namespace GLEducation.Lib.Data
{
    public class LogRepository 
    {
        private readonly LogDBContext _dbContext;
        public LogRepository(LogDBContext  dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task AddData(LogData logMessage)
        {
            await _dbContext.LogDatas.AddAsync(logMessage);
            await _dbContext.SaveChangesAsync();
        }
    }
}