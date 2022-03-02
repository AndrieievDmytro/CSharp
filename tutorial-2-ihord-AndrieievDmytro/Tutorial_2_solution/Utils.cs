using System.IO;
using System.Linq;

public  class Utils {
    public  bool isExists(string path)
    {
        return File.Exists(path);
    }

    public  bool isCorrectPass(string path)
    {
        char [] pathSymbols = Path.GetInvalidPathChars();
        return pathSymbols.Any( symb => path.Contains(symb));
    }
}