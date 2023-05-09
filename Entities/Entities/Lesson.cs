using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string img_Url { get; set; }
        public string Name { get; set; }
        public string content { get; set; }
        public DateTime lesson_time { get; set; }
        public Teacher teacher { get; set; }
        public int TeacherId { get; set; }
    
    }
}
