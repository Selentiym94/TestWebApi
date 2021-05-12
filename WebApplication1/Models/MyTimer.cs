using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Timers;



namespace WebApplication1.Models
{
	public class Mytimer
	{
		public static void SetTimer(int a)
		{
			Timer timer = new Timer(a);
			timer.Elapsed += OneTimerEvents;
			timer.AutoReset = true;
			if (a < 2)
			{
				timer.Enabled = false;
			}
			else
			{
				timer.Enabled = true;
			}

		}
		private static void OneTimerEvents(object sourse, ElapsedEventArgs e)
		{
			EntityuserContext ContextDataUser = new EntityuserContext();
			ContextDataUser.UpdateUserStatus();
		}
	}
}