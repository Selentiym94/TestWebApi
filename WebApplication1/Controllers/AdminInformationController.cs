using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class AdminInformationController : Controller
	{
		EntityuserContext ContextDataUser = new EntityuserContext();
		DeviceContext ContextDataDevice = new DeviceContext();

		[HttpGet]
		public ActionResult Info(int id)
        {
			//id относится к пользователю
			Mytimer.SetTimer(1);
			//ViewBag.check = true;
			ViewBag.Admin = ContextDataUser.GetUserById(id);
			ViewBag.AdminDevices = ContextDataDevice.GetDevicesByUserId(id);
			ViewBag.Entityuser = ContextDataUser.GetUserByName("");
			ViewBag.UserDevices = ContextDataDevice.GetDevicesByUserId(0);
			return View();
        }

		[HttpPost]
		public ActionResult Info(string view, int id)
		{
			ViewBag.view = view;
			//ViewBag.check = true;
			switch (view)
			{
				case "User":
					ViewBag.Admin = ContextDataUser.GetUserById(id); ;
					ViewBag.AdminDevices = ContextDataDevice.GetDevicesByUserId(id);

					ViewBag.Entityuser = ContextDataUser.GetAllUser();
					break;
				case "Device":
					ViewBag.Admin = ContextDataUser.GetUserById(id);
					ViewBag.AdminDevices = ContextDataDevice.GetDevicesByUserId(id);

					ViewBag.Entityuser = ContextDataUser.GetAllUser();
					ViewBag.Devices = ContextDataDevice.GetAllDevices();
					break;
				default:
					ViewBag.Admin = ContextDataUser.GetUserById(id);
					ViewBag.AdminDevices = ContextDataDevice.GetDevicesByUserId(id);
					break;
		
			}
			ViewBag.zeroId = ViewBag.Admin.Id;
			return View();
		}

		public ActionResult AddDevice(int UserId, int AdminId)
		{
			//id относится к пользователю (user или admin)
			//--------------------------------------------
			//Должна быть проверка на изменение: в текущем контролере изменения может вносит только администратор
			//--------------------------------------------
			ContextDataDevice.AddNewDevices(UserId);
			ViewBag.User = ContextDataUser.GetUserById(UserId);
			ViewBag.Admin = ContextDataUser.GetUserById(AdminId);
			return View();
		}

		public ActionResult DeleteDevice(int DeviceId, int AdminId)
		{
			//id относится к устройству (user или admin)
			ViewBag.Admin = ContextDataUser.GetUserById(AdminId);
			ViewBag.Device = ContextDataDevice.GetDevicesById(DeviceId);
			ViewBag.User = ContextDataUser.GetUserById(ViewBag.Device.UserId);
			if ((ViewBag.Admin.Role == "admin")||(ViewBag.Device.UserId==ViewBag.Admin.Id))
			{
				ContextDataDevice.DeleteDevice(DeviceId);
			}
			return View();
		}

		[HttpGet]
		public ActionResult ChangeDevice(int DeviceID, int AdminId)
		{
			//id относится к устройству (user или admin)
			ViewBag.Device = ContextDataDevice.GetDevicesById(DeviceID);
			ViewBag.User = ContextDataUser.GetUserById(ViewBag.Device.UserId);
			ViewBag.Admin = ContextDataUser.GetUserById(AdminId);
			ViewBag.mes = "";
			ViewBag.Today =DateTime.Today.ToString("yyyy-MM-dd");
			return View();
		}

		[HttpPost]
		public ActionResult ChangeDevice(int DeviceID, int AdminId, string status, string date)
		{
			//id относится к устройству (user или admin)
			ViewBag.Today = Convert.ToDateTime(date).ToString("yyyy-MM-dd");
			date = Convert.ToDateTime(date).ToString("d");
			//Если, при изменении данных об устройстве не выбрать статус по умолчанию назначится "inactive"
			//Если, при изменении данных об устройстве не выбрать дату по умолчанию назначится текущая
			if (status != "inactive" && status != "active")
			{
				status = "inactive";
			}
			Device d = new Device
			{
				Id = DeviceID,
				UserId = ContextDataDevice.GetDevicesById(DeviceID).UserId,
				Status =status,
				Date =date
			};
			ContextDataDevice.UpdateDevice(d);
			ViewBag.mes = "Изменения успешно внесены";
			ViewBag.Device = ContextDataDevice.GetDevicesById(DeviceID);
			ViewBag.User = ContextDataUser.GetUserById(ViewBag.Device.UserId);
			ViewBag.Admin = ContextDataUser.GetUserById(AdminId);
			return View();
		}

		[HttpGet]
		public ActionResult AddUser(int id)
		{
			ViewBag.Admin = ContextDataUser.GetUserById(id);
			if (ViewBag.Admin.Role == "admin")
			{
				ViewBag.mes = "";
				return View();
			}
			else
			{
				ViewBag.mes = "Нет прав для осуществления данной операции";
				return View();	
			}
			
		}

		[HttpPost]
		public ActionResult AddUser(int id, string name, string role, string status)
		{
			ViewBag.Admin = ContextDataUser.GetUserById(id);
			if (ViewBag.Admin.Role == "admin")
			{
				if (role != "user" && role != "admin")
				{
					role = "user";
				}
				if (status != "free" && status != "base" && status != "pro")
				{
					status = "free";
				}
				Entityuser newuser = new Entityuser
				{
					Name =name,
					Status = status,
					Role = role
				};
				ContextDataUser.AddNewUser(newuser);
				ViewBag.mes = "Добавление пользователя "+newuser.Name+" прошло успешно";
			}
			return View();
		}

		public ActionResult DeleteUser(int UserId, int AdminId)
		{
			if(AdminId != UserId)
			{
				ViewBag.check = true;
				ViewBag.Admin = ContextDataUser.GetUserById(AdminId);
				ViewBag.User = ContextDataUser.GetUserById(UserId);
				if (ViewBag.Admin.Role == "admin")
				{
					ViewBag.UserdeviceCount = ContextDataDevice.GetDevicesByUserId(UserId).Count;
					ContextDataDevice.DeleteAllDeviceOneUser(UserId);
					ContextDataUser.DeleteUser(UserId);
				}
			}
			else
			{
				ViewBag.check = false;
				ViewBag.mes = "Нельзя удалить себя!";
				ViewBag.Admin = ContextDataUser.GetUserById(AdminId);
				ViewBag.User = ContextDataUser.GetUserById(UserId);
			}
	
			return View();
		}

		[HttpGet]
		public ActionResult ChangeUser(int UserId, int AdminId)
		{
			ViewBag.Admin = ContextDataUser.GetUserById(AdminId);
			if (ViewBag.Admin.Role == "admin")
			{
				ViewBag.User = ContextDataUser.GetUserById(UserId);
				ViewBag.mes = "";
			}
			else
			{
				ViewBag.mes = "У пользователя " + ViewBag.Admin.Name + " нет доступа для осуществления данной операции";
			}
			return View();
		}

		[HttpPost]
		public ActionResult ChangeUser(int UserId, int AdminId, string name, string status, string role)
		{
			ViewBag.Admin = ContextDataUser.GetUserById(AdminId);
			var olddataUser = ContextDataUser.GetUserById(UserId);
			if (ViewBag.Admin.Role == "admin")
			{
				if (role != "user" && role != "admin")
				{
					role = "user";
				}
				if (status != "free" && status != "base" && status != "pro")
				{
					status = "free";
				}
				Entityuser updateuser = new Entityuser
				{
					Id=UserId,
					Name = name,
					Status = status,
					Role = role
				};
				ContextDataUser.UpdateUser(updateuser);
				ViewBag.User = ContextDataUser.GetUserById(UserId);
				ViewBag.mes = "Изменения данных пользователя " + olddataUser.Name + " прошло успешно";
			}
			else
			{
				ViewBag.mes = "У пользователя " + ViewBag.Admin.Name + " нет доступа для осуществления данной операции";
			}
			return View();
		}
	}
}