using Business.Concrete;
using DataAccessLayer.EfCore;
using Microsoft.AspNetCore.Mvc;

namespace MusicLessonProject.ViewComponents
{
    public class _Teachers:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            TeacherManager teacherManager = new TeacherManager(new EfCoreTeacherDal());
            var value = teacherManager.TGetList();
            return View(value);
        }
    }
}
