using System.Reflection;
using WeatherMonitor.Domain.Attributes;
using WeatherMonitor.Domain.Entities;

namespace WeatherMonitor.Domain
{
    public class DataPointService : IDataPointService
    {

        /// <summary>
        ///  Select data points from the given station weather data
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>A list for matching records for the given tag</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="AmbiguousMatchException"></exception>
        /// <exception cref="TypeLoadException"></exception>
        public List<DataPointEntity> GetDataPoint(string tag, List<WeatherDataEntity> weatherData)
        {
            return weatherData.Select(data =>
            {
                var list = data.GetType().GetProperties().Select(p =>
                 {
                     var attribute = p.GetCustomAttribute<TagAttribute>();
                     if (attribute != null && attribute.ID.ToUpper() == tag.ToUpper())
                         return new DataPointEntity(tag, p.GetValue(data)?.ToString() ?? string.Empty);

                     return null;

                 });


                return list.Where(l=> l is not null).FirstOrDefault() ?? new DataPointEntity(string.Empty, string.Empty);
            }).ToList();
        }

        /// <summary>
        /// Get all the available tags for a given weather record
        /// </summary>
        /// <returns></returns>
        public List<string> GetDataPointTags()
        {
            return new List<string> {
                        "Lat",
                        "Lon",
                        "ApparentTemperature",
                        "Cloud",
                        "CloudBaseMeters",
                        "CloudOktas",
                        "CloudType",
                        "CloudTypeId",
                        "DeltaT",
                        "GustKmh",
                        "GustKt",
                        "AirTemperature",
                        "DewPoint",
                        "Pressure",
                        "PressureMsl",
                        "PressureQnh",
                        "PressureTrend",
                        "RainTrace",
                        "RelativeHumidity",
                        "SeaState",
                        "SwellDirectionWorded",
                        "SwellHeight",
                        "SwellPeriod",
                        "VisibilityKm",
                        "Weather",
                        "WindDirection",
                        "WindSpeedKmh",
                        "WindSpeedKt",
            };
        }

        /// <summary>
        /// Get all the available weather observation stations
        /// </summary>
        /// <returns>All the weather stations</returns>
        public List<StationEntity> GetStations()
        {
            return new List<StationEntity>
            {
                new("94648", "Adelaide (West Terrace/ngayirdapira)"),
                new("94672", "Adelaide Airport"),
                new("95676", "Edinburgh"),
                new("94677", "Hindmarsh Island"),
                new("94683", "Kuitpo"),
                new("94806", "Mount Barker"),
                new("94678", "Mount Crawford"),
                new("95678", "Mount Lofty"),
                new("94808", "Noarlunga"),
                new("94681", "Nuriootpa"),
                new("95675", "Outer Harbor (Black Pole)"),
                new("95677", "Parafield"),
                new("94811", "Parawa West"),
                new("95679", "Sellicks Hill"),
                new("94814", "Strathalbyn"),
                new("95811", "Victor Harbor"),
                new("95805", "Cape Borda"),
                new("94822", "Cape Willoughby"),
                new("94809", "Edithburgh"),
                new("94685", "Kadina"),
                new("95807", "Kingscote"),
                new("94665", "Maitland"),
                new("95659", "Minlaton Airport"),
                new("94807", "Parndana"),
                new("95806", "Stenhouse Bay"),
                new("94666", "Warburto Point"),
                new("94813", "Cape Jaffa"),
                new("94817", "Coonawarra"),
                new("94816", "Keith"),
                new("95815", "Keith West"),
                new("94821", "Mount Gambier"),
                new("94820", "Naracoorte"),
                new("95823", "Padthaway"),
                new("95816", "Robe Airport"),
                new("95813", "Karoonda"),
                new("94690", "Lameroo AWS"),
                new("94682", "Loxton"),
                new("95812", "Murray Bridge"),
                new("95818", "Pallamana"),
                new("95687", "Renmark Airport"),
                new("95667", "Clare"),
                new("94680", "Eudunda"),
                new("95666", "Port Augusta"),
                new("99749", "Port Pirie Airport AWS"),
                new("95671", "Roseworthy"),
                new("95670", "Snowtown"),
                new("94679", "Yongala"),
                new("94653", "Ceduna"),
                new("94661", "Cleve"),
                new("94662", "Cleve Airport"),
                new("95683", "Cultana (Defence)"),
                new("95663", "Cummins Airport"),
                new("94656", "Elliston"),
                new("94668", "Kimba"),
                new("94657", "Kyancutta"),
                new("95662", "Minnipa RS"),
                new("94804", "Neptune Island"),
                new("94651", "Nullarbor"),
                new("95649", "Point Avoid"),
                new("95661", "Port Lincoln Airport"),
                new("94654", "Streaky Bay"),
                new("95652", "Thevenard"),
                new("95664", "Whyalla"),
                new("95654", "Wudinna Airport"),
                new("95660", "Andamooka"),
                new("95458", "Coober Pedy Airport"),
                new("94474", "Ernabella/Pukatja"),
                new("95668", "Gluepot"),
                new("94674", "Leigh Creek"),
                new("95480", "Marree Airport"),
                new("95481", "Moomba Airport"),
                new("94660", "Mount Ive"),
                new("94476", "Oodnadatta"),
                new("95658", "Roxby Downs"),
                new("94655", "Tarcoola"),
                new("94659", "Woomera"),
                new("94684", "Yunta")
            };

        }
    }
}
