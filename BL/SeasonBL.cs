using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Season = Entities.Season;

namespace BL
{
	public class SeasonBL
	{
		public async Task<int> AddOrUpdateAsync(Season entity)
		{
			entity.Id = await new SeasonDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new SeasonDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(SeasonSearchParams searchParams)
		{
			return new SeasonDal().ExistsAsync(searchParams);
		}

		public Task<Season> GetAsync(int id)
		{
			return new SeasonDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new SeasonDal().DeleteAsync(id);
		}

		public Task<SearchResult<Season>> GetAsync(SeasonSearchParams searchParams)
		{
			return new SeasonDal().GetAsync(searchParams);
		}
	}
}

