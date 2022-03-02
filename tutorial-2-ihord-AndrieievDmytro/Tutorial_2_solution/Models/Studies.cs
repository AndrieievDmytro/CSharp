using System;
using System.Text.Json.Serialization;
public class Studies {
    [JsonPropertyNameAttribute("name")]
    public String Name { get; set; }
    [JsonPropertyNameAttribute("mode")]
    public String Mode { get; set; }

}
