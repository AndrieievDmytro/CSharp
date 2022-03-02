using System.IO;
using System.Collections.Generic;
using System.Linq;
public class CSVReader : BasicReader<HashSet<Student>> 
{
private static readonly int _columnNum = 9;
    public CSVReader(ILogger logger, Utils utils) : base(logger, utils) {  }

    public override HashSet<Student> Read(string path)
    {
      base.Read(path);

        
        using var stream = new StreamReader(File.OpenRead(path));
        string line  = "";
        int lineCounter = 1;
        var students = new HashSet<Student>();
    

        while ((line = stream.ReadLine()) != null)
        {
            string [] parcedData = line.Split(',')
                                        .Select(w =>  w.Trim())
                                        .ToArray();
            
            if (parcedData.Length != _columnNum) 
            {
                _logger.ErrorLog($"Line{lineCounter}: Invalid number of columns.");
                continue;
            }

            if (parcedData.Any(t => t == "" || t == null ))
            {
                _logger.ErrorLog($"Line{lineCounter}: Empty field.");
                continue;
            }

            var student = new Student 
            {
                Fname = parcedData[0],
                Lname = parcedData[1],
                Studies = new Studies
                {  
                   Name = parcedData[2],
                   Mode = parcedData[3] 
                },
                IndexNumber = parcedData[4],
                Birthdate = parcedData[5],
                Email = parcedData[6],
                MotherName = parcedData[7],
                FatherName = parcedData[8]
            };

            if(students.Contains(student))
            {
                _logger.ErrorLog($"Line{lineCounter}: Duplicated data.");
            }
            else
            {
                students.Add(student);
            }
            lineCounter++;
        }
        return students;
    }
}