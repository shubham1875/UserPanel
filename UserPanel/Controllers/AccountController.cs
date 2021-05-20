using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserPanel.Models;

namespace UserPanel.Controllers
{
    public class AccountController : Controller
    {
        StockSystemEntities db = new StockSystemEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
            Session["UserEmail"] = account.Email.ToString();
            Session["UserName"] = account.Name.ToString();
            return RedirectToAction("Logged");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account account)
        {
            var user = db.Accounts.Single(x => x.Email == account.Email && x.Password == account.Password);
            if (user != null)
            {
                Session["UserEmail"] = user.Email.ToString();
                Session["UserName"] = user.Name.ToString();
                return RedirectToAction("Logged");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Logged()
        {
            if (Session["UserEmail"] != null)
            {
                List<PurchaseItem> list = db.PurchaseItems.OrderByDescending(x => x.id).ToList();
                return View(list);
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult PurchaseItems()
        {
            List<string> list = db.Products.Select(x => x.ProductName).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult PurchaseItems(PurchaseItem item)
        {
            db.PurchaseItems.Add(item);
            db.SaveChanges();
            return RedirectToAction("Logged");
        }

    }
}