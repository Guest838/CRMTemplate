using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class CountryModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "DescriptionFamousDishes")]
		public string DescriptionFamousDishes { get; set; }

		public static CountryModel FromEntity(Country obj)
		{
			return obj == null ? null : new CountryModel
			{
				Id = obj.Id,
				Name = obj.Name,
				DescriptionFamousDishes = obj.DescriptionFamousDishes,
			};
		}

		public static Country ToEntity(CountryModel obj)
		{
			return obj == null ? null : new Country(obj.Id, obj.Name, obj.DescriptionFamousDishes);
		}

		public static List<CountryModel> FromEntitiesList(IEnumerable<Country> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Country> ToEntitiesList(IEnumerable<CountryModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
