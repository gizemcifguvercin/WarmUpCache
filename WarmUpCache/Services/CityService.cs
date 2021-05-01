using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using WarmUpCache.DAL;
using WarmUpCache.Models;

namespace WarmUpCache.Services
{
    public class CityService : ICityService
    {
        private ICityRepository _cityRepository;
        private IMemoryCache _memoryCache;
        public CityService(ICityRepository cityRepository, IMemoryCache memoryCache)
        {
            _cityRepository = cityRepository;
            _memoryCache = memoryCache;
        }
        
        public List<City> GetCityListFromCache() => _memoryCache.GetOrCreate("cityList", entry => _cityRepository.GetCityList());

        public List<City> GetCityList()
        {
            return GetCityListFromCache();
        }
    }
}