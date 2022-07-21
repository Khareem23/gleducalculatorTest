using System;
using System.Threading.Tasks;
using GLEducation.Lib.Entities;

namespace GLEducation.Lib.Data
{
    public class LogRepository : ILogRepository
    {
        private readonly LogDBContext _dbContext;
        public LogRepository(LogDBContext  dbContext)
        {
            _dbContext = dbContext;
        }
        
        public  Task SaveData(LogData logMessage)
        {
            _dbContext.LogDatas.Add(logMessage);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}