
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

    public async Task<Sensor> UpdateSensor(Sensor updateSensor)
    {
        _db.Sensors.Update(updateSensor);
        await _db.SaveChangesAsync();
        return updateSensor;
    }

    public async Task<Sensor?> GetSensorByMacAddress(string macAddress)
    {
        return await _db.Sensors
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.MacAddress == macAddress);
    }

    public async Task<List<Sensor>> GetAllSensorAsync()
    {
        return await _db.Sensors.AsNoTracking().OrderBy(s => s.MacAddress).ToListAsync();
    }
}