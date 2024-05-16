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
	public class SeasonDal : BaseDal<DefaultDbContext, Season, Entities.Season, int, SeasonSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public SeasonDal()
		{
		}

		protected internal SeasonDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Season entity, Season dbObject, bool exists)
		{
			dbObject.Name = entity.Name;
			dbObject.MonthStart = entity.MonthStart;
			dbObject.MonthEnd = entity.MonthEnd;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Season>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Season> dbObjects, SeasonSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Season>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Season> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Season, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Season, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Season ConvertDbObjectToEntity(Season dbObject)
		{
			return dbObject == null ? null : new Entities.Season(dbObject.Id, dbObject.Name, dbObject.MonthStart,
				dbObject.MonthEnd);
		}
	}
}
