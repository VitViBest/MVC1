using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskMVC1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Reviews()
        {
            return View();
        }

        public ActionResult Questions()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Questions(string name, string age,string model,string complect,string[] additional)
        {
            if (name == null || name.Length == 0)
                ModelState.AddModelError("","Не указано имя!");
            else
            if (name.Any(x=>!Char.IsLetter(x)))
                ModelState.AddModelError("", "Неверно указано имя!");
            if (age == null || age.Length == 0)
                ModelState.AddModelError("", "Не указан возраст!");
            else
            if (age.Any(x => !Char.IsNumber(x))||int.Parse(age)==0)
                ModelState.AddModelError("", "Неверно указан возраст!");
            if (model == null || model.Length == 0)
                ModelState.AddModelError("", "Не указана модель!");
            else
            if (model.Replace(" ","").Length==0)
                ModelState.AddModelError("", "Неверно указана модель!");
            if (complect == null || complect.Length == 0)
                ModelState.AddModelError("", "Не указана комплектация!");
            if (!ModelState.IsValid)
            {
                return View();
            }
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Model= model;
            ViewBag.Complect = complect;
            ViewBag.Additional = additional == null ? new string[0]:additional ;
            return View("Show");
        }
    }
}