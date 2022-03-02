using System;
public interface ILogger {
    void ErrorLog(Exception ex );
    void ErrorLog(string message );
}