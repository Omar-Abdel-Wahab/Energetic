using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IP_Project.Models;
namespace IP_Project.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext _context;

        public NewsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: News
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult News()
        {
            var news = _context.News.OrderByDescending(n => n.date).ToList();
            foreach (var item in news) {
                char c = item.image.ElementAt(item.image.Length - 1);
                if (c == 'c')
                {

                }
                else {
                    item.image += 'c';
                }
                item.image = "../../images/" + item.image + ".jpg";
            }
            return View(news);
        }
        public ActionResult NewsSingle(int id)
        {
            var item = _context.News.SingleOrDefault(i => i.id == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            else {
                var singleNews = item;
                var path = "../../images/";
                var ext = ".jpg";
                int c = item.image.LastIndexOf('c');
                if (c == -1)
                {
                    singleNews.image = path + item.image + "n" + ext;
                }
                else
                {
                    singleNews.image = path + item.image.Replace('c', 'n') + ext;
                }
                
                return View(singleNews);
            }
        }
    }
}