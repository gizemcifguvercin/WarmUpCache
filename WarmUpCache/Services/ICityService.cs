using System.Collections.Generic;
using WarmUpCache.Models;

namespace WarmUpCache.Services
{
    public interface ICityService
    {
        List<City> GetCityListFromCache();
        List<City> GetCityList();
    }
}