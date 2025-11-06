
using BackendAspNetCore.Dtos.Sensor;
using BackendAspNetCore.Mappers;
using BackendAspNetCore.Models;
using BackendAspNetCore.Repositories.SensorRepo;
using BackendAspNetCore.Dtos.Response;
using BackendAspNetCore.Utils;

namespace BackendAspNetCore.Services.SensorServices;

public class SensorService : ISensorService
{
    private readonly ISensorRepository _iSensorRepo;

    public SensorService(ISensorRepository iSensorRepo)
    {
        _iSensorRepo = iSensorRepo;
    }

    public async Task<ApiResponse> SaveOrUpdateSensorAsync(AddSensorRequestBody input)
    {
        SensorDto sensorDto;
        Sensor? existSensor = await _iSensorRepo.GetSensorByMacAddress(input.MacAddress);
        if (existSensor != null)
        {
            existSensor.Temperature = input.Temperature;
            existSensor.Humidity = input.Humidity;
            existSensor.LastUpdatedUtc = DatetimeUtil.GetCurrentUtcDatetime();
            _iSensorRepo.UpdateSensor();
            sensorDto = SensorMapper.ToDto(existSensor);

            return ApiResponse<SensorDto>.SuccessResponse(sensorDto, "Sensor has been updated", 200);
        }
        var newSensor = new Sensor
        {
            MacAddress = input.MacAddress,
            Temperature = input.Temperature,
            Humidity = input.Humidity,
            LastUpdatedUtc = DatetimeUtil.GetCurrentUtcDatetime(),
        };
        Sensor sensor = await _iSensorRepo.SaveSensor(newSensor);
        sensorDto = SensorMapper.ToDto(sensor); 
        return ApiResponse<SensorDto>.SuccessResponse(sensorDto, "New sensor has been added", 200);
    }
}