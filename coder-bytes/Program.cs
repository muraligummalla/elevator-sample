using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Collections.Generic;

namespace coder_bytes
{
    class Program
    {
        static void Main(string[] args)
        {
            WebRequest request = WebRequest.Create("https://coderbyte.com/api/challenges/json/age-counting");
            WebResponse response = request.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string content = reader.ReadToEnd();
            response.Close();

            int count = content
                .Split(':')[1]
                .Trim('{', '}', '\"')
                .Split(',')
                .Where(x => x.Trim()
                .Split('=')[0] == "age")
                .Where(x => Convert.ToInt32(x.Split('=')[1]) > 50)
                .Count();
            Console.WriteLine(count);
        }
    }
}
