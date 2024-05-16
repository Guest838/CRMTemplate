using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Dish = Entities.Dish;

namespace BL
{
	public class DishBL
	{
		public async Task<int> AddOrUpdateAsync(Dish entity)
		{
			entity.Id = await new DishDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new DishDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(DishSearchParams searchParams)
		{
			return new DishDal().ExistsAsync(searchParams);
		}

		public Task<Dish> GetAsync(int id)
		{
			return new DishDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new DishDal().DeleteAsync(id);
		}

		public Task<SearchResult<Dish>> GetAsync(DishSearchParams searchParams)
		{
			return new DishDal().GetAsync(searchParams);
		}
	}
}

