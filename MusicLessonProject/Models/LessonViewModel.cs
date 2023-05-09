using Entities.Entities;

namespace MusicLessonProject.Models
{
    public class LessonViewModel
    {
        public int LessonId { get; set; }
        public string img_Url { get; set; }
        public string Name { get; set; }
        public string content { get; set; }
        public DateTime lesson_time { get; set; }
        public Teacher teacher { get; set; }
    }
}
