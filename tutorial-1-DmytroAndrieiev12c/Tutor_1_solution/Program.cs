using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Linq;

namespace Tutor_1_solution
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var url = args.Length > 0 ? args[0] : throw new ArgumentNullException("You should pass a link as an argument");

            // ^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$ URL Regex verification

            if(!Uri.IsWellFormedUriString(args[0], UriKind.Absolute))
            {
                throw new ArgumentException("Invalid URL");
            }

            using   (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.GetAsync(url);

                if (result.IsSuccessStatusCode)
                {
                    string htmlContent = await result.Content.ReadAsStringAsync();
                    processEmails(htmlContent);
                }
                else
                {
                    Console.WriteLine("Error while downloading the page");
                }
            }
        }
        public static void processEmails(string content)
        {
            string MatchEmailPattern = @"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@(([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})";
            Regex regex = new Regex(MatchEmailPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Match m = regex.Match(content);

            if (!m.Success)
            {
                Console.WriteLine("E-mail addresses not found.");
                return;
            }
            regex.Matches(content)
                    .Select(m => m.Value)
                    .Distinct()
                    .ToList()
                    .ForEach(m => Console.WriteLine($"Email: {m}\n"));
        }
    }
}
