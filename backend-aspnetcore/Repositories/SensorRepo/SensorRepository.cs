
using BackendAspNetCore.Data;
using BackendAspNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendAspNetCore.Repositories.SensorRepo;

public class SensorRepository : ISensorRepository
{
    private readonly AppDbContext _db;
    public SensorRepository(AppDbContext db) => _db = db;

    public async Task<Sensor> SaveSensor(Sensor newSensor)
    {
        _db.Sensors.Add(newSensor);
        await _db.SaveChangesAsync();
        return newSensor;
    }

    public async void UpdateSensor()
    {
        await _db.SaveChangesAsync();
    }

    public async Task<Sensor?> GetSensorByMacAddress(string macAddress)
    {
        return await _db.Sensors
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.MacAddress == macAddress);
    }
}