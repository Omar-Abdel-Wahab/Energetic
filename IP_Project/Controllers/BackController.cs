using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IP_Project.Models;

namespace IP_Project.Controllers
{
    public class BackController : Controller
    {
        private ApplicationDbContext _context;

        public BackController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Back
        public ActionResult Index()
        {
            var admins = _context.Admins.ToList();
            return View(admins);
        }

        public ActionResult CreateANews(News news)
        {
            if (news.id == 0)
            {
                _context.News.Add(news);
            }
            else
            {
                var newsInDB = _context.News.SingleOrDefault(n => n.id == news.id);
                newsInDB.image = news.image;
                newsInDB.title = news.title;
                newsInDB.content = news.content;
                newsInDB.date = news.date;
            }
            _context.SaveChanges();
            return RedirectToAction("News", "Back");
        }
        public ActionResult CreateAnEvent(Event ev)
        {
            if (ev.id == 0)
            {
                _context.Events.Add(ev);
            }
            else
            {
                var eventsInDB = _context.Events.SingleOrDefault(e => e.id == ev.id);
                eventsInDB.image = ev.image;
                eventsInDB.title = ev.title;
                eventsInDB.content = ev.content;
                eventsInDB.date = ev.date;
            }
            _context.SaveChanges();
            return RedirectToAction("Events", "Back");
        }

        public ActionResult DeleteAnAdmin(int id) {
            var adminInDB = _context.Admins.SingleOrDefault(a => a.id == id);
            if (adminInDB == null)
            {
                return HttpNotFound();
            }
            else {
                _context.Admins.Remove(adminInDB);
                _context.SaveChanges();
                return RedirectToAction("Index", "Back");
            }
        }
        public ActionResult DeleteANews(int id)
        {
            var newsInDB = _context.News.SingleOrDefault(a => a.id == id);
            if (newsInDB == null)
            {
                return HttpNotFound();
            }
            else
            {
                _context.News.Remove(newsInDB);
                _context.SaveChanges();
                return RedirectToAction("News", "Back");
            }
        }
        public ActionResult DeleteAnEvent(int id)
        {
            var eventInDB = _context.Events.SingleOrDefault(a => a.id == id);
            if (eventInDB == null)
            {
                return HttpNotFound();
            }
            else
            {
                _context.Events.Remove(eventInDB);
                _context.SaveChanges();
                return RedirectToAction("Events", "Back");
            }
        }
        public ActionResult CreateAdmin() {
                return View();
                     
        }

        public ActionResult CreateAnAdmin(Admin admin) {
            if (admin.id == 0)
            {
                _context.Admins.Add(admin);
            }
            else
            {
                var adminInDB = _context.Admins.SingleOrDefault(a => a.id == admin.id);
                adminInDB.name = admin.name;
                adminInDB.role = admin.role;
                adminInDB.password = admin.password;
                adminInDB.email = admin.email;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Back");
        }

        public ActionResult EditAnAdmin(int id)
        {
            var adminInDB = _context.Admins.SingleOrDefault(a => a.id == id);
            if (adminInDB == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("CreateAdmin", adminInDB);
            }
        }
        public ActionResult EditANews(int id)
        {
            var newsInDB = _context.News.SingleOrDefault(a => a.id == id);
            if (newsInDB == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("CreateNews", newsInDB);
            }
        }
        public ActionResult EditAnEvent(int id)
        {
            var eventInDB = _context.Events.SingleOrDefault(a => a.id == id);
            if (eventInDB == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("CreateEvent", eventInDB);
            }
        }

        public ActionResult News() {
            var news = _context.News.ToList();
            return View(news);
        }

        public ActionResult Events()
        {
            var events = _context.Events.ToList();
            return View(events);
        }
        public ActionResult CreateNews()
        {
            return View();
        }

        public ActionResult CreateEvent()
        {
            return View();
        }

    }
}