﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MobileInfo.Models;
using System.Web.UI;

namespace MobileInfo.Controllers
{
    public class AdminController : Controller
    {
		// GET: Admin

		private DB16Entities db = new DB16Entities();

		public ActionResult BIndex()
		{
			using (DB16Entities db = new DB16Entities())
			{
				return View(db.Brands.ToList());
			}

		}

		[HttpGet]
		public ActionResult AdminLogin()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AdminLogin(Administrator l)
		{
			if (l.Email == "admin123@gmail.com")
			{
				if (l.Password == "1")
				{
					return RedirectToAction("ALoggedIn");
				}
				else
				{
					TempData["msg"] = "<script>alert('Login Failed');</script>";
				}
			}
			else
			{
				TempData["msg"] = "<script>alert('Login Failed');</script>";
			}
			return RedirectToAction("AdminLogin");
		}

		public ActionResult ALoggedIn()
		{
			return View();
		}

		[HttpGet]
		public ActionResult RegisterBrand()
		{
			return View();
		}

		[HttpPost]
		public ActionResult RegisterBrand(Brand obj)
		{
			string fileName = Path.GetFileNameWithoutExtension(obj.ImageFile.FileName);
			string extension = Path.GetExtension(obj.ImageFile.FileName);
			fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
			obj.Image = "~/Image/" + fileName;
			fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
			obj.ImageFile.SaveAs(fileName);
			using (DB16Entities db = new DB16Entities())
			{
				db.Brands.Add(obj);
				db.SaveChanges();
				ModelState.Clear();
				obj = null;
	
				ViewBag.Message = "Registered Successful";
				return RedirectToAction("RegisterBrand");
			}
		}

		public ActionResult MIndex()
		{
			using (DB16Entities db = new DB16Entities())
			{
				return View(db.Mobiles.ToList());
			}

		}

		[HttpGet]
		public ActionResult RegisterMobile(int id = 0)
		{
			Mobile m = new Mobile();
			using (DB16Entities db = new DB16Entities())
			{
				if (id != 0)
				{
					m = db.Mobiles.Where(x => x.Id == id).FirstOrDefault();
				}
				m.BrandCollection = db.Brands.ToList<Brand>();
			}
			return View(m);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult RegisterMobile(Mobile obj)
		{
			string fileName = Path.GetFileNameWithoutExtension(obj.ImageFile1.FileName);
			string extension = Path.GetExtension(obj.ImageFile1.FileName);
			fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
			obj.Picture = "~/Image/" + fileName;
			fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
			obj.ImageFile1.SaveAs(fileName);
			using (DB16Entities db = new DB16Entities())
			{
				db.Mobiles.Add(obj);
				db.SaveChanges();
				ModelState.Clear();
				obj = null;

				TempData["msg"] = "<script>alert('Register successfully');</script>";
				return RedirectToAction("RegisterMobile");
			}
		}

		public ActionResult MEdit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Mobile s = db.Mobiles.SingleOrDefault(x => x.Id == id);
			if (s == null)
			{
				return HttpNotFound();
			}
			return View(s);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult MEdit(Mobile obj)
		{
			string fileName = Path.GetFileNameWithoutExtension(obj.ImageFile1.FileName);
			string extension = Path.GetExtension(obj.ImageFile1.FileName);
			fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
			obj.Picture = "~/Image/" + fileName;
			fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
			obj.ImageFile1.SaveAs(fileName);
			db.Entry(obj).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("MIndex");

		}

		public ActionResult MDelete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Mobile user = db.Mobiles.Find(id);
			if (user == null)
			{
				return HttpNotFound();
			}
			return View(user);
		}


		[HttpPost, ActionName("MDelete")]
		[ValidateAntiForgeryToken]
		public ActionResult MDeleteConfirmed(int id)
		{
			Mobile user = db.Mobiles.Find(id);
			//dbStudent student = db.dbStudents.SingleOrDefault(x => x.S_Email == user.LoginEmail);
			//db.dbStudents.Remove(student);
			db.Mobiles.Remove(user);
			db.SaveChanges();
			return RedirectToAction("MIndex");
		}

		// GET: Admin/Details/5
		public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

		[HttpGet]
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Brand s = db.Brands.SingleOrDefault(x => x.Id == id);
			if (s == null)
			{
				return HttpNotFound();
			}
			return View(s);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Brand obj)
		{
			string fileName = Path.GetFileNameWithoutExtension(obj.ImageFile.FileName);
			string extension = Path.GetExtension(obj.ImageFile.FileName);
			fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
			obj.Image = "~/Image/" + fileName;
			fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
			obj.ImageFile.SaveAs(fileName);
			db.Entry(obj).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("BIndex");
			
		}

		public ActionResult BDelete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Brand user = db.Brands.Find(id);
			if (user == null)
			{
				return HttpNotFound();
			}
			return View(user);
		}


		[HttpPost, ActionName("BDelete")]
		[ValidateAntiForgeryToken]
		public ActionResult BDeleteConfirmed(int id)
		{
			Brand user = db.Brands.Find(id);
			//dbStudent student = db.dbStudents.SingleOrDefault(x => x.S_Email == user.LoginEmail);
			//db.dbStudents.Remove(student);
			db.Brands.Remove(user);
			db.SaveChanges();
			return RedirectToAction("BIndex");
		}

		public ActionResult BDetails(int? id)
		{
			Brand b = new Brand();
			using (DB16Entities db = new DB16Entities())
			{
				b = db.Brands.Where(x => x.Id == id).FirstOrDefault();
			}
			return View(b);
		}
	}
}
