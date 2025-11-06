
namespace BackendAspNetCore.Services.SensorServices;
public interface ISensorService
{
    public Task<ApiResponse> SaveOrUpdateSensorAsync(AddSensorRequestBody input);
}