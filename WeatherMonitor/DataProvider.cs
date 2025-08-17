using System.Data;

namespace WeatherMonitor
{
    public class DataProvider : IDataProvider
    {
        private readonly IAPIClient _api;
        public DataProvider(IAPIClient api)
        {
            _api = api;

        }
        public async Task<(DataTable,string, string)> GetDataTable(string wmo)
        {
            DataTable tbl = setColumns();
            string msg = string.Empty;
            string averageTemp = string.Empty;
            var response = await _api.GetWeather(wmo);
            if (response != null && response.Data != null && response.Data.Items != null)
            {

                foreach (var item in response.Data.Items)
                {

                    tbl.Rows.Add([
                    item.LocalDateTime, item.Lat,item.Lon,item.AirTemperature,item.Cloud,item.CloudBaseMeters,item.CloudOktas,item.CloudType,
                    item.CloudTypeId ?? string.Empty,item.DeltaT,item.DewPoint,item.GustKmh,item.GustKt,item.Pressure,item.PressureMsl,
                    item.PressureQnh,item.PressureTrend,item.RainTrace,item.RelativeHumidity,item.SeaState,item.SwellDirectionWorded,
                    item.SwellHeight ?? string.Empty,item.SwellPeriod  ?? string.Empty,item.VisibilityKm,item.Weather,item.WindDirection,item.WindSpeedKmh,
                    item.WindSpeedKt
                    ]);


                }

                msg = response.Data.Items.First().Message;
                averageTemp = response.Data.AverageTemperature.ToString();
            }

            return (tbl, msg, averageTemp) ;
        }

        public async Task<DataTable> GetDataTable(string wmo,string tag)
        {
            DataTable tbl =new DataTable();

            var response = await _api.GetWeatherDataForDataPoint(tag, wmo);
            if (response != null && response.Data != null)
            {
                tbl.Columns.Add(tag);
                foreach (var item in response.Data)
                    tbl.Rows.Add([item.Value]);
            }

            return tbl;
        }

        

        private DataTable setColumns()
        {
            DataTable tbl = new DataTable();
            var columnNames = new List<string>()
            {
                "Date/Time","Lat","Lon","Temp","Cloud","Cl.BM","Cl.oktas","Cl.Type",
                "Cl.TyID","DeltaT","DewPt","GustKmh","GustKt","Pressure","PresMsl",
                "PresQnh","PresTrnd","RainTrace","Rel.Hum","SeaState","SwellDirWrd",
                "SwellH","SwellP","Visi.Km","weather","WindDir","WindSpd","Windspdkt"
            };

            foreach (var col in columnNames)
                tbl.Columns.Add(col);

            return tbl;
        }
    }
}
