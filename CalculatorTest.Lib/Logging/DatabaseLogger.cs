using System.Threading.Tasks;
using GLEducation.Lib.Data;
using GLEducation.Lib.Entities;

namespace GLEducation.Lib.Logging
{
    public class DatabaseLogger : IDiagnosticLogger
    {
        private readonly ILogRepository _iLogRepository;
        public DatabaseLogger(ILogRepository logRepository)
        {
            _iLogRepository = logRepository;
        }
        public Task log(LogData message)
        {
             _iLogRepository.SaveData(message);
             return Task.CompletedTask;
        }
    }
}