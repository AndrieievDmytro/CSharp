using System;
public static class FileFormat{
    public static string toString(FormatEnum formatEnum) => 
        formatEnum switch 
        {
            FormatEnum.JSON => "json",
            _ => "There is no such format"
        };
        public static FormatEnum GetFormat(string format) =>
        format.ToLower() switch 
        {
            "json" => FormatEnum.JSON,
            null => throw new ArgumentNullException(),
            _ => throw new ArgumentException()
        };
}
