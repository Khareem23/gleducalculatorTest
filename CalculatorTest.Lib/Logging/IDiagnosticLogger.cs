using System.Threading.Tasks;
using GLEducation.Lib.Entities;

namespace GLEducation.Lib.Logging
{
    public interface IDiagnosticLogger
    {
        Task log(LogData message);
    }
}