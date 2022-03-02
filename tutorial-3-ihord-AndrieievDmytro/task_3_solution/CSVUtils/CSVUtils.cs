using System.IO;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data;

public class CSVUtils 
{
    private readonly string _pathToFile;
    
    public CSVUtils(string path)
    {
        _pathToFile = path;
    }
    
    public  List<Student> Read()
    {
        using var stream = new StreamReader(File.OpenRead(_pathToFile));
        string line  = "";
        var students = new List<Student>();
        var parameters = typeof(Student).GetProperties();
        while ((line = stream.ReadLine()) != null)
        {
            string [] parcedData = line.Split(',')
                                        .Select(w =>  w.Trim())
                                        .ToArray();
            
            if (9 != parameters.Length) 
            {
                throw new Exception("Invalied number of columns"); 
            }

            if (parcedData.Any(t => t == "" || t == null ))
            {
                throw new Exception("Empty fields");
            }

            var student = new Student 
            {
                Fname = parcedData[0],
                Lname = parcedData[1],
                IndexNumber = parcedData[2],
                Birthdate = parcedData[3], 
                Studies = parcedData[4],
                Mode = parcedData[5],
                Email = parcedData[6],
                FatherName = parcedData[7],
                MotherName = parcedData[8]
            };

                students.Add(student);
        }
        return students;
    }

    public void Write<Student>(List <Student> students)
    { 
        var parametres = typeof(Student).GetProperties();
        using var stream = new StreamWriter(_pathToFile, false);
 
        string sep ="";
        foreach (Student parameter in students )
        {
            string line = "";

            for (int i = 0; i < parametres.Length; i++ )
            {
                if (i == parametres.Length -1){
                    sep = "";
                }
                else
                {
                    sep = ",";
                }
                line += parametres[i].GetValue(parameter).ToString() + sep;
            }
            stream.WriteLine(line); 
        }
    }

    public void InsertData(List<Student> students, Student student)
    {
        var parametres = typeof(Student).GetProperties();
        using var stream = new StreamWriter(_pathToFile, true);

        if(students.Contains(student))
        {
            throw new Exception("There already exists such object");
        }

        string line = "";
        string sep ="";

        for (int i = 0; i < parametres.Length; i++)
        {
             if (i == parametres.Length -1){
                    sep = "";
                }
                else
                {
                    sep = ",";
                }
            line += parametres[i].GetValue(student).ToString() + sep;
        }
        stream.WriteLine(line);
    }
}