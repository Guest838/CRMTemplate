using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Country = Entities.Country;

namespace BL
{
	public class CountryBL
	{
		public async Task<int> AddOrUpdateAsync(Country entity)
		{
			entity.Id = await new CountryDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new CountryDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(CountrySearchParams searchParams)
		{
			return new CountryDal().ExistsAsync(searchParams);
		}

		public Task<Country> GetAsync(int id)
		{
			return new CountryDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new CountryDal().DeleteAsync(id);
		}

		public Task<SearchResult<Country>> GetAsync(CountrySearchParams searchParams)
		{
			return new CountryDal().GetAsync(searchParams);
		}
	}
}

