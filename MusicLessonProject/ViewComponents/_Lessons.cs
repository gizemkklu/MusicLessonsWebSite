using Business.Concrete;
using DataAccessLayer.EfCore;
using Microsoft.AspNetCore.Mvc;

namespace MusicLessonProject.ViewComponents
{
    public class _Lessons:ViewComponent
    {


        public IViewComponentResult Invoke()
        {
            LessonManager lessonManager = new LessonManager(new EfCoreLessonDal());

            var value = lessonManager.GetListByTeacher();
            return View(value);
        }
    }
}

