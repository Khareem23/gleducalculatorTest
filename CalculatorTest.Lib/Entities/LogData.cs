using System;

namespace GLEducation.Lib.Entities
{
    public class LogData
    {
        public DateTime DateLogged { get; set; } = DateTime.Now;
        public string Operation { get; set; }
        public string Result { get; set; }
        
    }
}