namespace WeatherMonitor.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class TagAttribute: Attribute
    {
        public string ID { get; }
        public TagAttribute(string Id) { 
            ID = Id;
        }
    }
}
