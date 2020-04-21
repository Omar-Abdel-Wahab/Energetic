using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IP_Project.Models;
namespace IP_Project.Model
{
    public class EventsController : Controller
    {
        private ApplicationDbContext _context;

        public EventsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Events
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Events()
        {
            var evs = _context.Events.OrderByDescending(e => e.date).ToList();
            foreach (var item in evs)
            {
                char c = item.image.ElementAt(item.image.Length - 1);
                if (c == 'c')
                {

                }
                else
                {
                    item.image += 'c';
                }
                item.image = "../../images/" + item.image + ".jpg";
            }
            return View(evs);
        }
        public ActionResult EventsSingle(int id)
        {
            var item = _context.Events.SingleOrDefault(i => i.id == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            else
            {
                var singleEvent = item;
                var path = "../../images/";
                var ext = ".jpg";
                int c = item.image.LastIndexOf('c');
                if (c == -1)
                {
                    singleEvent.image = path + item.image + "n" + ext;
                }
                else
                {
                    singleEvent.image = path + item.image.Replace('c', 'n') + ext;
                }

                return View(singleEvent);
            }
        }

    }
}