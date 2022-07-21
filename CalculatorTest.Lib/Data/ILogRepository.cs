using System.Threading.Tasks;
using GLEducation.Lib.Entities;

namespace GLEducation.Lib.Data
{
    public interface ILogRepository
    {
        Task SaveData(LogData logMessage);
    }
}