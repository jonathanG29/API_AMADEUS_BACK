using API_AMADEUS.Models;
using Microsoft.EntityFrameworkCore;

namespace API_AMADEUS.Data;

public class CityRepository
{
    private readonly ApplicationDbContext db;

    public CityRepository(ApplicationDbContext context)
    {
        db = context;
    }

    public async Task<List<City>> GetAllCities()
    {
        return await db.Cities.ToListAsync();
    }


    public async Task<City?> GetCityById(int id)
    {
        return await db.Cities.FirstOrDefaultAsync(city => city.Id == id);
    }

}
