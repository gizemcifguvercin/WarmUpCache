using System.Collections.Generic;
using WarmUpCache.Models;

namespace WarmUpCache.DAL
{
    public interface ICityRepository
    {
        List<City> GetCityList();
    }
}