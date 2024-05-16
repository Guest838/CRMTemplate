using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class SeasonModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "MonthStart")]
		public int MonthStart { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "MonthEnd")]
		public int MonthEnd { get; set; }

		public static SeasonModel FromEntity(Season obj)
		{
			return obj == null ? null : new SeasonModel
			{
				Id = obj.Id,
				Name = obj.Name,
				MonthStart = obj.MonthStart,
				MonthEnd = obj.MonthEnd,
			};
		}

		public static Season ToEntity(SeasonModel obj)
		{
			return obj == null ? null : new Season(obj.Id, obj.Name, obj.MonthStart, obj.MonthEnd);
		}

		public static List<SeasonModel> FromEntitiesList(IEnumerable<Season> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Season> ToEntitiesList(IEnumerable<SeasonModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
