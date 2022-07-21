using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using GLEducation.Lib.Entities;

namespace GLEducation.Lib.Logging
{
    public class DebugLogger : IDiagnosticLogger
    {
        public Task log(LogData message)
        {
            Debug.WriteLine(
                $"Operation : {message.Operation}=> Logged Datetime: {message.DateLogged}, message : {message.Result}");
            return Task.CompletedTask;
        }
    }
}