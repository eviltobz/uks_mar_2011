using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetstore.web.core
{
	public class CommandUrl
	{
		public static string to_run<T>()
		{
			return string.Format("http://server/{0}.uk", typeof(T).Name);
		}
	}
}
