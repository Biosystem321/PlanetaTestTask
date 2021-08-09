using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planeta.Models;

namespace Planeta.Controllers
{
    public class HomeController : Controller
    {
        IEnumerable<Sex> sexes = new List<Sex>
        {
            new Sex { Id = 1, Value = "Мужской" },
            new Sex { Id = 2, Value = "Женский" }
        };

        IUserRepository repository;
        public HomeController(IUserRepository r)
        {
            repository = r;
        }
        public ActionResult Index()
        {
            return View(repository.GetUsers());
        }

        public ActionResult Details(int id)
        {
            User user = repository.Get(id);
            if (user != null)
                return View(user);
            return NotFound();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            repository.Create(user);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            User user = repository.Get(id);
            if (user != null)
                return View(user);
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            repository.Update(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            User user = repository.Get(id);
            if (user != null)
                return View(user);
            return NotFound();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
