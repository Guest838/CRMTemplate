using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Dish
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int CountryId { get; set; }
		public int SeasonId { get; set; }

		public Dish(int id, string name, int countryId, int seasonId)
		{
			Id = id;
			Name = name;
			CountryId = countryId;
			SeasonId = seasonId;
		}
	}
}
