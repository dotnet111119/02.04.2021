using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestClient
{
    class Program
    {
        public static string ReadFromUrl(string url)
        {
            string read_str = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // read data
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                read_str = reader.ReadToEnd();
            }
            return read_str;
        }

        static void Main(string[] args)
        {
            string st1 = ReadFromUrl("https://randomuser.me/api");
            Console.WriteLine(st1);
            JObject data = JObject.Parse(st1);

            // get the inner field country in one line....
            // dynamic obj = JsonConvert.DeserializeObject(st1);
            // var arr1 = obj.results[0].location.country;

            var ja = JArray.Parse(data.GetValue("results").ToString());

            // this is how to iterate over an array
            //foreach(JObject child in ja.Children<JObject>())
            //{
            //    var jo = JObject.Parse(child.ToString());
            //    var g1 = jo.GetValue("gender");
            //}

            var first = JObject.Parse(ja.Children<JObject>().First().ToString());
            var location = first.GetValue("location").ToString();

            var country = JObject.Parse(location).GetValue("country").ToString();

            Console.WriteLine(data);

            Console.WriteLine(data);
        }
    }
}
