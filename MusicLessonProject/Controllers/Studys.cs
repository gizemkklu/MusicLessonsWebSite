using Business.Concrete;
using DataAccessLayer.EfCore;
using Microsoft.AspNetCore.Mvc;

namespace MusicLessonProject.Controllers
{
    public class Studys : Controller
    {
        LessonManager lessonManager = new LessonManager(new EfCoreLessonDal());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LessonDetails(int id)
        {
            ViewBag.Id = id;
            var value = lessonManager.TGetById(id);
            return View(value);
        }
    }
}
