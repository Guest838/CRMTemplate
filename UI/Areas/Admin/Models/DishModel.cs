using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class DishModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "CountryId")]
		public int CountryId { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "SeasonId")]
		public int SeasonId { get; set; }

		public static DishModel FromEntity(Dish obj)
		{
			return obj == null ? null : new DishModel
			{
				Id = obj.Id,
				Name = obj.Name,
				CountryId = obj.CountryId,
				SeasonId = obj.SeasonId,
			};
		}

		public static Dish ToEntity(DishModel obj)
		{
			return obj == null ? null : new Dish(obj.Id, obj.Name, obj.CountryId, obj.SeasonId);
		}

		public static List<DishModel> FromEntitiesList(IEnumerable<Dish> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Dish> ToEntitiesList(IEnumerable<DishModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
