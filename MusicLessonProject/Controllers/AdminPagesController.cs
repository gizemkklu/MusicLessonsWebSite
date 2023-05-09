using Business.Abstract;
using Entities.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicLessonProject.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MusicLessonProject.Controllers
{
    [Authorize]
    public class AdminPagesController : Controller
    {
        private readonly ILessonService _lessonService;
        private readonly ITeacherService _teacherService;
        private readonly IContactService _contactService;

        public AdminPagesController(ILessonService lessonService, ITeacherService teacherService, IContactService contactService)
        {
            _lessonService = lessonService;
            _teacherService = teacherService;
            _contactService = contactService;
        }

        public IActionResult Index() //  Dashboard
        {
            ViewBag.Bildirim2 = _contactService.TGetListByOkundu().Count();
            ViewBag.Bildirim = _contactService.TGetListByOkunacak().Count();
            ViewBag.Ders = _lessonService.TGetList().Count();
            ViewBag.teacher = _teacherService.TGetList().Count();
            return View();
        }

        //Dersler----------------------------
        [HttpGet]
        public IActionResult Dersler()
        {
            var value = _lessonService.GetListByTeacher();
            return View(value);
        }
        [HttpGet]
        public IActionResult DersEkle()
        {
            List<SelectListItem> values = (from x in _teacherService.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.TeacherId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public IActionResult DersEkle(Lesson p)
        {
           
            _lessonService.TAdd(p);
            return RedirectToAction("Dersler", "AdminPages");
        }
        public IActionResult DersSil(int id)
        {
            var value = _lessonService.TGetById(id);
            _lessonService.TDelete(value);
            return RedirectToAction("Dersler","AdminPages");
        }

        //Eğitmenler----------------------
        public IActionResult Eğitmenler()
        {
            var value = _teacherService.TGetList();
            return View(value);
        }

        [HttpGet]
        public IActionResult EgitmenEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EgitmenEkle(EğitmenEkleViewModel p)
        {
            Teacher teacher = new Teacher();
            if(p.img_Url != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extesion = Path.GetExtension(p.img_Url.FileName);
                var imagename = Guid.NewGuid() + extesion;
                var savelocation = resource + "wwwroot/music/images/profile/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                 p.img_Url.CopyToAsync(stream);
                teacher.img_Url = imagename;

            }
            
            teacher.Name = p.Name;
            teacher.Surname = p.Surname;
            teacher.About = p.About;
            _teacherService.TAdd(teacher);
            return RedirectToAction("Eğitmenler", "AdminPages");
        }

        public IActionResult EgitmenSil(int id)
        {
            var value = _teacherService.TGetById(id);
            _teacherService.TDelete(value);
            return RedirectToAction("Eğitmenler", "AdminPages");
        }



        //Çıkış----------------------------
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Studys");
        }
    }
}
