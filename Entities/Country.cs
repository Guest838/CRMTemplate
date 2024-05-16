using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Country
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string DescriptionFamousDishes { get; set; }

		public Country(int id, string name, string descriptionFamousDishes)
		{
			Id = id;
			Name = name;
			DescriptionFamousDishes = descriptionFamousDishes;
		}
	}
}
