using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Controllers;
using WebApplication1.Models;
using WebApplication1;

namespace WebApplication1.Controllers
{
	public class HomeController : Controller
	{
		EntityuserContext ContextData = new EntityuserContext();

		[HttpGet]
		public ActionResult Info()
		{
			//Mytimer.SetTimer(5000);
			ViewBag.Entityuser = ContextData.GetUserByName("");
			return View();
		}

		[HttpPost]
		public ActionResult Info(Entityuser user)
		{
			ViewBag.Entityuser = ContextData.GetUserByName(user.Name);
			return View();

		}
	}
}