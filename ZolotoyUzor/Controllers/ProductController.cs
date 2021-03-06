﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZolotoyUzor.Models;
using ZolotoyUzor.Models.Filters;

namespace ZolotoyUzor.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
			var els = Paint.GetAllPaints();

			return View(els);
        }
		public ActionResult Item(int id)
		{
			var el = Paint.GellPaintByID(id);

			return View(el);
		}
		public JsonResult GetPaints(PaintFilter filter)
		{

			return new JsonResult() { };
		}
    }
}