using System;
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

		public ActionResult Index()
        {
            return View();
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

		[HttpGet]
		public ActionResult RegisterMobile()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult RegisterMobile(Mobile obj)
		{
			using (DB16Entities db = new DB16Entities())
			{
				Mobile m = new Mobile();
				m.Name = obj.Name;
				m.OS = obj.OS;
				m.UI = obj.UI;
				m.Dimensions = obj.Dimensions;
				m.Weight = obj.Weight;
				m.SIM = obj.SIM;
				m.Colors = obj.Colors;
				m.C2G_Band = obj.C2G_Band;
				m.C3G_Band = obj.C3G_Band;
				m.C4G_Band = obj.C4G_Band;
				m.CPU = obj.CPU;
				m.GPU = obj.GPU;
				m.Chipset = obj.Chipset;
				m.Technology = obj.Technology;
				m.Size = obj.Size;
				m.Resolution = obj.Resolution;
				m.Built_in_Memory = obj.Built_in_Memory;
				m.Card = obj.Card;
				m.Main_Camera = obj.Main_Camera;
				m.Camera_Description = obj.Camera_Description;
				m.Features = obj.Features;
				m.Front_Camera = obj.Front_Camera;
				m.WLAN = obj.WLAN;
				m.Bluetooth = m.Bluetooth;
				m.GPS = obj.GPS;
				m.NFC = obj.NFC;
				m.USB = obj.USB;
				m.Data = obj.Data;
				m.Sensors = obj.Sensors;
				m.Audio = obj.Audio;
				m.Browser = obj.Browser;
				m.Messaging = obj.Messaging;
				m.Games = obj.Games;
				m.Torch = obj.Torch;
				m.Extra = obj.Extra;
				m.Battery = obj.Battery;
				m.Price = obj.Price;
				m.Announced_On = obj.Announced_On;
				m.Status = obj.Status;
				m.Description = obj.Description;
				m.BrandId = 1;
				m.Picture = obj.Picture;
				db.Mobiles.Add(m);
				db.SaveChanges();

				ViewBag.Message = "Registered Successful";
				return RedirectToAction("ALoggedIn, Admin");
			}
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
