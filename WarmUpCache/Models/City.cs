namespace WarmUpCache.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        public City(int CityId, string CityName)
        {
            this.CityId = CityId;
            this.CityName = CityName;
        }
    }
}