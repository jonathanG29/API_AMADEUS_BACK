using API_AMADEUS.Data;
using API_AMADEUS.Models;

namespace API_AMADEUS.Services;

public class CityService
{
    private readonly CityRepository cityRepository;

    public CityService(ApplicationDbContext context)
    {
        cityRepository = new CityRepository(context);
    }

    public async Task<List<City>> GetAllCities()
    {
        return await cityRepository.GetAllCities();
    }

    public async Task<City?> GetCityById(int id)
    {
        return await cityRepository.GetCityById(id);
    }
}
