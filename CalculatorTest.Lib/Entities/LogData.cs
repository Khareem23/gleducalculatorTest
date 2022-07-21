using System;

namespace GLEducation.Lib.Entities
{
    public class LogData
    {
        public int Id { get; set; }
        public string Operation { get; set; }
        public string Result { get; set; }
        public DateTime DateLogged { get; set; } = DateTime.Now;
        
    }
}