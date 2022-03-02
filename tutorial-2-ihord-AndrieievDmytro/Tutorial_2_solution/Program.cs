using System.Collections.Generic;
using System;

namespace Tutorial_2_solution
{
    class Program
    {
        private static readonly string  DEFAULT_PATH_CSV = "data.csv";
        private static readonly string  DEFAULT_PATH_RESULT = "result.json";
        private static readonly FormatEnum  DEFAULT_FORMAT_TYPE = FormatEnum.JSON;
        private static readonly string  DEFAULT_PATH_LOG = "log.txt";

        

        static void Main(string[] args)
        {
            ILogger logger = new Logger(DEFAULT_PATH_LOG);
            Utils utils = new Utils();
            IReader<HashSet<Student>> reader = new CSVReader(logger,utils);
            IWritter<University> writter = new JSONWritter<University>();

            try{
            string input = DEFAULT_PATH_CSV;
            string output = DEFAULT_PATH_RESULT;
            FormatEnum fileFormat = DEFAULT_FORMAT_TYPE;


            if (args.Length> 3 )
            {
                logger.ErrorLog("Too many parametres");
                return;
            }

            if(args.Length == 1)
            {
                input = args[0];
            }
            else if(args.Length == 2)
            {
                input = args[0];
                output = args[1];

            }
            else if (args.Length == 3)
            {
                input = args[0];
                output = args[1];
                fileFormat = FileFormat.GetFormat(args[2]);

            } 

            var students = reader.Read(input);
            var uni = University.createUni(students);
            writter.Write(output,uni);

            }catch(Exception e)
            {
                logger.ErrorLog(e);
            }
            
        }
    }
}
