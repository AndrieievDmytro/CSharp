using System;

public class Student {
    public String Fname { get; set; }
    public String Lname { get; set; }
    public String IndexNumber { get; set; }
    public String Birthdate { get; set; }
    public String Studies { get; set; }
    public String Mode { get; set; }
    public String Email { get; set; }
    public String FatherName { get; set; }
    public String MotherName { get; set; }
    
    public override bool Equals(object obj)
    {
        return obj is Student students &&
            IndexNumber.Equals(students.IndexNumber) ;
    }

    public override int GetHashCode()
    {
        return IndexNumber.GetHashCode();
    }
}