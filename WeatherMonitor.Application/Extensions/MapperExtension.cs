using WeatherMonitor.Application.Dto;
using WeatherMonitor.Application.Exceptions;
using WeatherMonitor.Domain.Entities;
using WeatherMonitor.Infrastructure;

namespace WeatherMonitor.Application.Extensions
{
    public static class MapperExtension
    {
        public static List<WeatherDataEntity> MapToEntity(this BOMResponse? response)
        {
            response = response ?? throw new InvalidMappingException(nameof(response), "The response property can not be null");

            var observations = response.observations ??
                throw new InvalidMappingException(nameof(response.observations), "The observation property can not be null");

            List<Datum> stationData = observations.data ??
                    throw new InvalidMappingException(nameof(response.observations.data), "The observation.data property can not be null");

            var header = observations.header ??
                 throw new InvalidMappingException(nameof(response.observations.header), "The observation.header property can not be null");

            string message = string.Empty;

            if (header.Count > 0)
                message = header.First().refresh_message ?? string.Empty;

            var list = stationData.Select(item => new WeatherDataEntity()
            {
                AifstimeUtc = item.aifstime_utc.Sanitize(),
                AirTemperature = item.air_temp.Sanitize(),
                ApparentTemperature = item.apparent_t.Sanitize(),
                Cloud = item.cloud.Sanitize(),
                CloudBaseMeters = item.cloud_base_m.Sanitize(),
                CloudOktas = item.cloud_oktas.Sanitize(),
                CloudType = item.cloud_type.Sanitize(),
                CloudTypeId = item.cloud_type_id,
                DeltaT = item.delta_t.Sanitize(),
                DewPoint = item.dewpt.Sanitize(),
                GustKmh = item.gust_kmh.Sanitize(),
                GustKt = item.gust_kt.Sanitize(),
                HistoryProduct = item.history_product.Sanitize(),
                Lat = item.lat.Sanitize(),
                LocalDateTime = item.local_date_time.Sanitize(),
                LocalDateTimeFull = item.local_date_time_full.Sanitize(),
                Lon = item.lon.Sanitize(),
                Message = message.Sanitize(),
                Name = item.name.Sanitize(),
                Pressure = item.press.Sanitize(),
                PressureMsl = item.press_msl.Sanitize(),
                PressureQnh = item.press_qnh.Sanitize(),
                PressureTrend = item.press_tend.Sanitize(),
                RainTrace = item.rain_trace.Sanitize(),
                RelativeHumidity = item.rel_hum.Sanitize(),
                SeaState = item.sea_state.Sanitize(),
                SortOrder = item.sort_order.Sanitize(),
                SwellDirectionWorded = item.swell_dir_worded.Sanitize(),
                SwellHeight = item.swell_height,
                SwellPeriod = item.swell_period,
                VisibilityKm = item.vis_km.Sanitize(),
                Weather = item.weather.Sanitize(),
                WindDirection = item.wind_dir.Sanitize(),
                WindSpeedKmh = item.wind_spd_kmh.Sanitize(),
                WindSpeedKt = item.wind_spd_kt.Sanitize(),
                Wmo = item.wmo

            }).ToList();

            
            return list;
        }

        public static WeatherDataDTO MapToDTO(this List<WeatherDataEntity>? entities)
        {
            entities = entities ?? throw new InvalidMappingException(nameof(entities), "The entities property can not be null");

            var list = entities.Select(item =>
             {
                 return new WeatherDataItem()
                 {
                     AifstimeUtc = item.AifstimeUtc,
                     AirTemperature = item.AirTemperature,
                     ApparentTemperature = item.ApparentTemperature,
                     Cloud = item.Cloud,
                     CloudBaseMeters = item.CloudBaseMeters,
                     CloudOktas = item.CloudOktas,
                     CloudType = item.CloudType,
                     CloudTypeId = item.CloudTypeId,
                     DeltaT = item.DeltaT,
                     DewPoint = item.DewPoint,
                     GustKmh = item.GustKmh,
                     GustKt = item.GustKt,
                     HistoryProduct = item.HistoryProduct,
                     Lat = item.Lat,
                     LocalDateTime = item.LocalDateTime,
                     LocalDateTimeFull = item.LocalDateTimeFull,
                     Lon = item.Lon,
                     Message = item.Message,
                     Name = item.Name,
                     Pressure = item.Pressure,
                     PressureMsl = item.PressureMsl,
                     PressureQnh = item.PressureQnh,
                     PressureTrend = item.PressureTrend,
                     RainTrace = item.RainTrace,
                     RelativeHumidity = item.RelativeHumidity,
                     SeaState = item.SeaState,
                     SortOrder = item.SortOrder,
                     SwellDirectionWorded = item.SwellDirectionWorded,
                     SwellHeight = item.SwellHeight,
                     SwellPeriod = item.SwellPeriod,
                     VisibilityKm = item.VisibilityKm,
                     Weather = item.Weather,
                     WindDirection = item.WindDirection,
                     WindSpeedKmh = item.WindSpeedKmh,
                     WindSpeedKt = item.WindSpeedKt,
                     Wmo = item.Wmo

                 };
             }).ToList();

            return new WeatherDataDTO() { Items = list };
        }

        public static List<StationDTO> MapToStationDTO(this List<StationEntity> list)
        {
            if (list == null || list.Count == 0) return [];
            return list.Select(p => new StationDTO(p.ID, p.Name)).ToList();
        }

        public static List<DataPointDTO> MapToDataPointDTO(this List<DataPointEntity> list)
        {
            if (list == null || list.Count == 0) return [];
            return list.Select(p => new DataPointDTO(p.Tag,p.Value)).ToList();
        }
    }
}
