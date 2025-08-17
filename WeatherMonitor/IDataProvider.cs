using System.Data;

namespace WeatherMonitor
{
    public interface IDataProvider
    {
        Task<(DataTable, string, string)> GetDataTable(string wmo);
        Task<DataTable> GetDataTable(string wmo, string tag);
    }
}