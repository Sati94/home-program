namespace Home_Program.Model
{
    public class ProgramIdea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public WeatherType IdealWeather { get; set; }
        public int UserId { get; set; }
    }
}
