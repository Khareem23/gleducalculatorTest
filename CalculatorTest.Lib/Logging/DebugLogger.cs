using System;
using System.Diagnostics;
using System.Globalization;

namespace GLEducation.Lib.Logging
{
    public class DebugLogger : IDiagnosticLogger
    {
        public void log(string message)
        {
            Debug.WriteLine($"Logged Datetime: {DateTime.Now.ToString(CultureInfo.InvariantCulture)}, message : {message}");
        }
    }
}