using System.IO;
using System;
public class Logger : ILogger {

    private string _pathToFile; 

    public Logger(string path){

        if (File.Exists(path))
        {
            File.Delete(path);
        }
        
            _pathToFile = path;
        
    }


    public void ErrorLog(Exception ex){
        File.AppendAllText(_pathToFile, ex + System.Environment.NewLine);
    }
    public void ErrorLog(string message)
    {
        File.AppendAllText(_pathToFile, message + System.Environment.NewLine); // \r\n for non-Unix platforms
    }

}