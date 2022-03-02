using System;
public interface IWritter<T> {
    void Write(string path, T data);
}