namespace API_AMADEUS.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public string Combination { get; set; }
        public int FirstCityId { get; set; }
        public int SecondCityId { get; set; }
    }
}
