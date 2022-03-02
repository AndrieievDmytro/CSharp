using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;


[Serializable]
public class University {
private static readonly string author = "Jan Kowalski";

    [JsonPropertyNameAttribute("createdAt")]
    public String CreateddAt { get; set; }
    [JsonPropertyNameAttribute("author")]
    public String Author { get; set; }
    [JsonPropertyNameAttribute("students")]
    public Student[] Students { get; set; }
    [JsonPropertyNameAttribute("activeStudies")]
    public ActiveStudies [] ActiveStudies { get; set; }


    public static University createUni(HashSet<Student>students) => new University
    {
        CreateddAt = DateTime.Now.ToString(),
        Author = author,
        Students = students.ToArray(),
        ActiveStudies = students.GroupBy(w => w.Studies.Name)
                    .Select(e => new ActiveStudies{
                        Name = e.Key,
                        NumberOfStudents = e.Count()
                        }).ToArray()
    };
}
