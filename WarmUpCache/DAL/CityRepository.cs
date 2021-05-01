using System.Collections.Generic;
using Serilog;
using WarmUpCache.Models;

namespace WarmUpCache.DAL
{
    public class CityRepository : ICityRepository
    {
        public List<City> GetCityList()
        {
            Log.Information("{Data} From DB!", "GetCityList");
            return new List<City>{
               new City(34, "İSTANBUL"),
               new City(35, "İZMİR")
          };
        }
    }
}