using Microsoft.AspNetCore.Mvc;

namespace MusicLessonProject.ViewComponents
{
    public class _Hakkımızda : ViewComponent 
    { 
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

    
}
