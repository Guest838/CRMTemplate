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
	public class CountryDal : BaseDal<DefaultDbContext, Country, Entities.Country, int, CountrySearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public CountryDal()
		{
		}

		protected internal CountryDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Country entity, Country dbObject, bool exists)
		{
			dbObject.Name = entity.Name;
			dbObject.DescriptionFamousDishes = entity.DescriptionFamousDishes;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Country>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Country> dbObjects, CountrySearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Country>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Country> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Country, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Country, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Country ConvertDbObjectToEntity(Country dbObject)
		{
			return dbObject == null ? null : new Entities.Country(dbObject.Id, dbObject.Name,
				dbObject.DescriptionFamousDishes);
		}
	}
}
