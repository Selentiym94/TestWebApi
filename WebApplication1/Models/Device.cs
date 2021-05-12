using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
	public class Device
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Status { get; set; }
		public string  Date { get; set; }
	}
}