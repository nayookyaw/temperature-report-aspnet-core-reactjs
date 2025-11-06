
using BackendAspNetCore.RequestBody.Sensor;

namespace BackendAspNetCore.Services.SensorServices;
public interface ISensorService
{
    public Task<ApiResponse> SaveOrUpdateSensorAsync(AddSensorRequestBody input);
    public Task<ApiResponse> GetAllSensorAsync(GetAllSensorRequestBody input);
}