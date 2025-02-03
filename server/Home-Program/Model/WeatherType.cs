using System.ComponentModel;

namespace Home_Program.Model
{
    public enum WeatherType
    {
        [Description("Napos")]
        Sunny,

        [Description("Felhős")]
        Cloudy,

        [Description("Esős")]
        Rainy,

        [Description("Havas")]
        Snowy,

        [Description("Szeles")]
        Windy,

        [Description("Viharos")]
        Stormy
    }
}
