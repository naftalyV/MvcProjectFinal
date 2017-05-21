﻿using MvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MvcProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
      
        public ActionResult HomePage(string Massege)
        {

            if (Massege != null)
            {
                ViewBag.Massege1 = Massege;
            }
            var list = new List<Product>();
            using (var ctx = new BuyForUDB())
            {
                list = ctx.Product.Where(p=>p.Status !=State.Sold).ToList();

                return View(list);
            }
        }
        public ActionResult ShowInHomePage(int id)
        {
            using (var ctx = new BuyForUDB())
            {

                var imageData = ctx.Product.Where(p => p.Id == id &&
                p.picture1!= null &&
                p.Status != State.Sold).FirstOrDefault();
                if (imageData!=null)
                {
                return File(imageData.picture1, "image/jpg");

                }
                return View();
            }
        }
        public ActionResult OrderByTitle()
        {
            List<Product> list;
            using (var ctx = new BuyForUDB())
            {
                list = ctx.Product.Where(p => p.Status != State.Sold)
                    .OrderBy(p => p.Title).ToList();
                return View("HomePage", list);
            }
        }

        public ActionResult OrderByDate()
        {
            List<Product> list;
            using (var ctx = new BuyForUDB())
            {
                list = ctx.Product.Where(p => p.Status != State.Sold).OrderBy(p => p.Date).ToList();
                return View("HomePage", list);
            }
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult MoreDedails(int id)
        {
            Product Dedails;
            using (var ctx = new BuyForUDB())
            {
               Dedails = ctx.Product.Include(p => p.Owner).Where(p => p.Id == id).FirstOrDefault();

            }
                return View(Dedails);
        }
        public ActionResult ShowPicture2(int id)
        {
            using (var ctx = new BuyForUDB())
            {

                var imageData = ctx.Product.Where(p => p.Id == id && p.picture2 != null).FirstOrDefault();

                return File(imageData.picture2, "image/jpg");
            }
        }
        public ActionResult ShowPicture3(int id)
        {
            using (var ctx = new BuyForUDB())
            {

                var imageData = ctx.Product.Where(p => p.Id == id && p.picture3 != null).FirstOrDefault();

                return File(imageData.picture3, "image/jpg");
            }
        }
    }
}
