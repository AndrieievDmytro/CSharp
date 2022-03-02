using System;
using System.Text.Json.Serialization;

public class ActiveStudies {
[JsonPropertyNameAttribute("name")]
public String Name { get; set; }
[JsonPropertyNameAttribute("numberOfStrudents")]
public int NumberOfStudents { get; set; }    
}
