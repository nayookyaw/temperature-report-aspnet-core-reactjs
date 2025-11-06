
using BackendAspNetCore.Models;

namespace BackendAspNetCore.Repositories.SensorRepo;
public interface ISensorRepository
{
    public Task<Sensor> SaveSensor(Sensor newSensor);
    public void UpdateSensor();
    public Task<Sensor?> GetSensorByMacAddress(string macAddress);
}