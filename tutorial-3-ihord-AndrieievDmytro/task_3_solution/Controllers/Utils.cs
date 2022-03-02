using System.Linq;
using System.Text.RegularExpressions;

public static class Utils {
    public static bool checkIndex(Student student)
    {
        var indexNumPattern = "s[0-9]{4}";
        var regex = new Regex(indexNumPattern,RegexOptions.IgnoreCase);
        return regex.IsMatch(student.IndexNumber);
    }
    public static bool checkNull(Student student)
    {
        var classParams = typeof(Student).GetProperties();
        return classParams.Any(c => c.GetValue(student).Equals("") || c.GetValue(student).Equals(null));
    }
}