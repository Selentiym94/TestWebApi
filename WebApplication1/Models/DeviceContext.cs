using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Data.Entity;

namespace WebApplication1.Models
{
	public class DeviceContext
	{
		public string ConnectString { get; set; }
		

		public DeviceContext(string connectTo = "Server=localhost;Port=5432;Username=postgres;Password='11223344';Database=testdbone")
		{
			ConnectString = connectTo;
		}
		
		//Получение списка устройств конкретного пользователя
		public List<Device> GetDevicesByUserId(int user_id)
		{
			List<Device> c = new List<Device>();
			var con = new NpgsqlConnection(ConnectString);
			

			string a = "SELECT * FROM Entitydevices WHERE user_id=" + user_id + ";";
			con.Open();
			if (con.State == ConnectionState.Open)
			{
				
				var cmd = new NpgsqlCommand(a, con);
				NpgsqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Device d = new Device
					{
						Id = Convert.ToInt32(reader[0].ToString()),
						UserId = Convert.ToInt32(reader[1].ToString()),
						Status=reader[2].ToString(),
						Date=reader[3].ToString()
					};
					c.Add(d);
				}
				reader.Close();
			}
			con.Close();
			return c;
		}

		//Получение списка всех устройств
		public List<Device> GetAllDevices()
		{
			List<Device> c = new List<Device>();
			var con = new NpgsqlConnection(ConnectString);

			string a = "SELECT * FROM Entitydevices;";
			con.Open();
			if (con.State == ConnectionState.Open)
			{

				var cmd = new NpgsqlCommand(a, con);
				NpgsqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Device d = new Device
					{
						Id = Convert.ToInt32(reader[0].ToString()),
						UserId = Convert.ToInt32(reader[1].ToString()),
						Status = reader[2].ToString(),
						Date = reader[3].ToString()
					};
					c.Add(d);
				}
				reader.Close();
			}
			con.Close();
			return c;
		}
		
		//Получение информации о конкретном устройстве
		public Device GetDevicesById(int id)
		{
			Device c = new Device();
			var con = new NpgsqlConnection(ConnectString);


			string a = "SELECT * FROM Entitydevices WHERE id=" + id + ";";
			con.Open();
			if (con.State == ConnectionState.Open)
			{

				var cmd = new NpgsqlCommand(a, con);
				NpgsqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{

					c.Id = Convert.ToInt32(reader[0].ToString());
					c.UserId = Convert.ToInt32(reader[1].ToString());
					c.Status = reader[2].ToString();
					c.Date = reader[3].ToString();
				}
				reader.Close();
			}
			con.Close();
			return c;
		}

		//Добавление нового устройства 
		public void AddNewDevices(int user_id)
		{
			var con = new NpgsqlConnection(ConnectString);
			DateTime thisDay = DateTime.Today;
			string a = "INSERT INTO entitydevices(user_id,status,date) VALUES("+ user_id + ",'inactive','"+ thisDay.ToString("d") + "');";
			con.Open();
			if (con.State == ConnectionState.Open)
			{

				var cmd = new NpgsqlCommand(a, con);
				NpgsqlDataReader reader = cmd.ExecuteReader();
				//------------------------------------------------------------------------//
				// в теории тут должна быть проверка, что количество добавленных записей=1 //
				//------------------------------------------------------------------------//
				reader.Close();
			}
			con.Close();
		}

		//Изменение информации об устройстве 
		public void UpdateDevice(Device device)
		{
			var con = new NpgsqlConnection(ConnectString);
			DateTime thisDay = DateTime.Today;
			string a = "UPDATE Entitydevices SET status='" + device.Status +"', date='"+ device.Date +"' WHERE id="+ device.Id +";";
			con.Open();
			if (con.State == ConnectionState.Open)
			{
				var cmd = new NpgsqlCommand(a, con);
				NpgsqlDataReader reader = cmd.ExecuteReader();
				//------------------------------------------------------------------------//
				// в теории тут должна быть проверка, что количество измененных записей=1 //
				//------------------------------------------------------------------------//
				reader.Close();
			}
			con.Close();
		}

		//Удаляет устройство из списка
		public void DeleteDevice(int device_id)
		{
			var con = new NpgsqlConnection(ConnectString);
			DateTime thisDay = DateTime.Today;
			string a = "DELETE FROM Entitydevices WHERE id=" + device_id+ ";";
			con.Open();
			if (con.State == ConnectionState.Open)
			{
				var cmd = new NpgsqlCommand(a, con);
				NpgsqlDataReader reader = cmd.ExecuteReader();
				//------------------------------------------------------------------------//
				// в теории тут должна быть проверка, что количество удаленных записей=1 //
				//------------------------------------------------------------------------//
				reader.Close();
			}
			con.Close();
		}

		//Удаляет все устройства конкретного пользователя
		public void DeleteAllDeviceOneUser(int user_id)
		{
			var con = new NpgsqlConnection(ConnectString);
			DateTime thisDay = DateTime.Today;
			string a = "DELETE FROM Entitydevices WHERE user_id=" + user_id + ";";
			con.Open();
			if (con.State == ConnectionState.Open)
			{
				var cmd = new NpgsqlCommand(a, con);
				NpgsqlDataReader reader = cmd.ExecuteReader();
				//------------------------------------------------------------------------------------//
				// в теории тут должно быть сообщение, что количество удаленных записей = столько-то //
				//----------------------------------------------------------------------------------//
				reader.Close();
			}
			con.Close();
		}
	}
}
