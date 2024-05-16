using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Season
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int MonthStart { get; set; }
		public int MonthEnd { get; set; }

		public Season(int id, string name, int monthStart, int monthEnd)
		{
			Id = id;
			Name = name;
			MonthStart = monthStart;
			MonthEnd = monthEnd;
		}
	}
}
