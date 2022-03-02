using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;

public class JSONWritter<T> : IWritter<T>
{
    public void Write(string path, T data)
    {

        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All),
            WriteIndented = true
        };
        var jsonString = JsonSerializer.Serialize(data, options);
        File.WriteAllText(path, jsonString);
    }
}