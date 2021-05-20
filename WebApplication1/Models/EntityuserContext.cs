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
	public class EntityuserContext
	{
		public string ConnectString { get; set; }

		public EntityuserContext(string connectTo = "Server=localhost;Port=5432;Username=postgres;Password='11223344';Database=testdbone")
		{
			ConnectString = connectTo;
		}

		//Поиск информации о пользователе по имени
		public Entityuser GetUserByName(string name)
		{
			Entityuser c = new Entityuser();
			var con = new NpgsqlConnection(ConnectString);
			string a = "SELECT * FROM Entityuser where name='" + name + "';";
			con.Open();
			if (con.State == ConnectionState.Open)
			{
				var cmd = new NpgsqlCommand(a, con);
				NpgsqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					c.Id = Convert.ToInt32(reader[0].ToString());
					c.Name = reader[1].ToString();
					c.Status = reader[2].ToString();
					c.Role = reader[3].ToString();
				}
				reader.Close();
			}
			con.Close();
			return c;
		}

		//Поиск информации о пользователе по ID
		public Entityuser GetUserById(int id)
		{
			Entityuser c = new Entityuser();
			var con = new NpgsqlConnection(ConnectString);
			string a = "SELECT * FROM Entityuser where id=" + id + ";";
			con.Open();
			if (con.State == ConnectionState.Open)
			{
				var cmd = new NpgsqlCommand(a, con);
				NpgsqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					c.Id = Convert.ToInt32(reader[0].ToString());
					c.Name = reader[1].ToString();
					c.Status = reader[2].ToString();
					c.Role = reader[3].ToString();
				}
				reader.Close();
			}
			con.Close();
			return c;
		}
		
		//Запрос всех на вывод всех пользователей
		public List<Entityuser> GetAllUser()
		{
			List<Entityuser> c = new List<Entityuser>();
			var con = new NpgsqlConnection(ConnectString);


			string a = "SELECT * FROM Entityuser;";
			con.Open();
			if (con.State == ConnectionState.Open)
			{

				var cmd = new NpgsqlCommand(a, con);
				NpgsqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Entityuser d = new Entityuser
					{
						Id = Convert.ToInt32(reader[0].ToString()),
						Name = reader[1].ToString(),
						Status=reader[2].ToString(),
						Role = reader[3].ToString(),
					};
					c.Add(d);
				}
				reader.Close();
			}
			con.Close();
			return c;
		}
		
		//Генерация случайного статуса
		public string GetStatus()
		{
			Random a = new Random();
			string[] b = { "free", "base", "pro" };
			int A=a.Next(3);
			return b[A];
		}
		
		//Обновление статусов всех пользователей в базе
		public  void UpdateUserStatus()
		{
			List<int> C = new List<int>();
			var con = new NpgsqlConnection(ConnectString);
			string a = "SELECT id FROM Entityuser WHERE role='user';";
			con.Open();
			if (con.State == ConnectionState.Open)
			{
				var cmd = new NpgsqlCommand(a, con);
				NpgsqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					C.Add(Convert.ToInt32(reader[0].ToString()));
				}
				reader.Close();
				foreach (var n in C)
				{
					string y = GetStatus();
					string b = "UPDATE Entityuser SET status='" + y + "' WHERE id=" + n + ";";
					cmd = new NpgsqlCommand(b, con);
					reader = cmd.ExecuteReader();
					//------------------------------------------------------------------------//
					// в теории тут должна быть проверка, что количество измененных записей=1 //
					//------------------------------------------------------------------------//
					reader.Close();
				}
			}
			con.Close();
		}

		//Добавление нового пользователя
		public void AddNewUser(Entityuser newuser)
		{
			var con = new NpgsqlConnection(ConnectString);
			DateTime thisDay = DateTime.Today;
			string a = "INSERT INTO entityuser(name,status,role) VALUES('"+newuser.Name+"','" + newuser.Status + "','" + newuser.Role + "');";
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

		//Удаляет устройство из списка
		public void DeleteUser(int user_id)
		{
			var con = new NpgsqlConnection(ConnectString);
			DateTime thisDay = DateTime.Today;
			string a = "DELETE FROM Entityuser WHERE id=" + user_id + ";";
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

		//Обновление данных пользователя
		public void UpdateUser(Entityuser user)
		{
			var con = new NpgsqlConnection(ConnectString);
			DateTime thisDay = DateTime.Today;
			string a = "UPDATE Entityuser SET name='" + user.Name + "',status='" + user.Status + "',role='" + user.Role + "' WHERE id="+user.Id+";";
			con.Open();
			if (con.State == ConnectionState.Open)
			{

				var cmd = new NpgsqlCommand(a, con);
				NpgsqlDataReader reader = cmd.ExecuteReader();
				//--------------------------------------------------------------------------//
				// в теории тут должна быть проверка, что количество обновлененых записей=1 //
				//--------------------------------------------------------------------------//
				reader.Close();
			}
			con.Close();
		}
	}
}
