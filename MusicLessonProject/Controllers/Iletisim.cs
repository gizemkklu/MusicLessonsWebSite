using Business.Abstract;
using Business.Concrete;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using MusicLessonProject.Models;

namespace MusicLessonProject.Controllers
{
    public class Iletisim : Controller
    {
        private readonly IContactService _contactService;

        public Iletisim(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(SendMessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                _contactService.TAdd(new Contact()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Mail = model.Mail,
                    Phone = model.Phone,
                    Subject = model.Subject,
                    MessageContent = model.MessageContent,
                    MessageStatus = true,
                    MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });

                return RedirectToAction("Index","Studys");
            }
            return View();
        }
    }
}
