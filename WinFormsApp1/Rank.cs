using System.Text.Json.Serialization;

namespace WinFormsApp1
{
    [JsonConverter(typeof(JsonStringEnumConverter))]  // This makes JSON use strings instead of numbers
    public enum Rank : short
    {
        Ustegmen = 0,
        Tegmen = 1,
        Astegmen = 2
    }
    
}