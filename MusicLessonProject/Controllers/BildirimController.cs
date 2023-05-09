using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MusicLessonProject.Controllers
{
    public class BildirimController : Controller
    {
        private readonly IContactService _contactService;

        public BildirimController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
           var value = _contactService.TGetList();
            return View(value);
        }
        public IActionResult MessageDelete(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return RedirectToAction("Index","Bildirim");
        }
        public IActionResult OkunanMesaj()
        {
          var value = _contactService.TGetListByOkundu();
            return View(value);
        }

        public IActionResult OkunmayanMesaj()
        {
            var value = _contactService.TGetListByOkunacak();
            return View(value);
        }
        
        public IActionResult OpenMessage(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TChangeToFalse(id);
            return View(value);
        }
    }
}
