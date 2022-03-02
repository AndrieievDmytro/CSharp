using System;
using System.Text.Json.Serialization;

public class Student {
    [JsonPropertyNameAttribute("indexNumber")]
    public String IndexNumber { get; set; }
    [JsonPropertyNameAttribute("fname")]
    public String Fname { get; set; }
    [JsonPropertyNameAttribute("lname")]
    public String Lname { get; set; }
    [JsonPropertyNameAttribute("birthdate")]
    public String Birthdate { get; set; }
    [JsonPropertyNameAttribute("email")]
    public String Email { get; set; }
    [JsonPropertyNameAttribute("motherName")]
    public String MotherName { get; set; }
    [JsonPropertyNameAttribute("fatherName")]
    public String FatherName { get; set; }
    [JsonPropertyNameAttribute("studies")]
    public Studies Studies { get; set; }

    public override bool Equals(object obj)
    {
        return obj is Student students &&
            IndexNumber == students.IndexNumber &&
            Fname == students.Fname  &&
            Lname == students.Lname;  
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(IndexNumber, Fname, Lname);
    }
}
