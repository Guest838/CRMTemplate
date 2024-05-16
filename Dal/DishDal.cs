using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Common.Enums;
using Common.Search;
using Dal.DbModels;

namespace Dal
{
	public class DishDal : BaseDal<DefaultDbContext, Dish, Entities.Dish, int, DishSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public DishDal()
		{
		}

		protected internal DishDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Dish entity, Dish dbObject, bool exists)
		{
			dbObject.Name = entity.Name;
			dbObject.CountryId = entity.CountryId;
			dbObject.SeasonId = entity.SeasonId;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Dish>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Dish> dbObjects, DishSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Dish>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Dish> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Dish, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Dish, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Dish ConvertDbObjectToEntity(Dish dbObject)
		{
			return dbObject == null ? null : new Entities.Dish(dbObject.Id, dbObject.Name, dbObject.CountryId,
				dbObject.SeasonId);
		}
	}
}
