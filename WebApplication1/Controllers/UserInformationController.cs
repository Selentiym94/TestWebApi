using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserInformationController : Controller
    {
        EntityuserContext ContextDataUser = new EntityuserContext();
        DeviceContext ContextDataDevice = new DeviceContext();		

        public ActionResult Info(int id)
        {
			//id относится к пользователю
			ViewBag.Entityuser = ContextDataUser.GetUserById(id);
			ViewBag.Devices = ContextDataDevice.GetDevicesByUserId(id);
			return View();
		}

		[HttpGet]
		public ActionResult Change(int id)
		{
			//id относится к устройству
			ViewBag.Devices = ContextDataDevice.GetDevicesById(id);
			ViewBag.Entityuser = ContextDataUser.GetUserById(ViewBag.Devices.UserId);
			ViewBag.mes = "";
			ViewBag.Today = DateTime.Today.ToString("yyyy-MM-dd");
			return View();
		}

		[HttpPost]
		public ActionResult Change(Device device)
		{
			ViewBag.Today = Convert.ToDateTime(device.Date).ToString("yyyy-MM-dd");
			device.Date = Convert.ToDateTime(device.Date).ToString("d");
			//Если, при изменении данных об устройстве не выбрать статус по умолчанию назначится "inactive"
			//Если, при изменении данных об устройстве не выбрать дату по умолчанию назначится текущая
			if (device.Status != "inactive"&& device.Status != "active")
			{
				device.Status = "inactive";
			}
			ContextDataDevice.UpdateDevice(device);
			ViewBag.mes = "Изменения успешно внесены";
			ViewBag.Devices = ContextDataDevice.GetDevicesById(device.Id);
			ViewBag.Entityuser = ContextDataUser.GetUserById(ViewBag.Devices.UserId);
			return View();
		}

		public ActionResult Add(int id)
		{
			//id относится к пользователю
			ViewBag.Entityuser = ContextDataUser.GetUserById(id);
			ViewBag.Devices = ContextDataDevice.GetDevicesByUserId(id);

			if ((ViewBag.Devices.Count < 3 && ViewBag.Entityuser.Status == "free") ||
				(ViewBag.Devices.Count < 10 && ViewBag.Entityuser.Status == "base")||
				ViewBag.Entityuser.Status == "pro")
			{
				ContextDataDevice.AddNewDevices(ViewBag.Entityuser.Id);
				ViewBag.ErorMassage = "Устройство успешно добавлено!";
			}
			else
			{
				ViewBag.ErorMassage = "Добавление невозможно!";
			}
			ViewBag.Devices = ContextDataDevice.GetDevicesByUserId(id);
			return View();
		}

		public ActionResult Delete(int id)
		{
			// id относится к устрйоству
			Device device = ContextDataDevice.GetDevicesById(id);
			ContextDataDevice.DeleteDevice(id);
			ViewBag.Entityuser = ContextDataUser.GetUserById(device.UserId);
			ViewBag.Devices = ContextDataDevice.GetDevicesByUserId(ViewBag.Entityuser.Id);
			return View();
		}
	}
}
 