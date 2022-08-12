using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JLDN.network
{
    internal class bumpVersion
    {
        /*
 * API RELEASE TAG CALL FORAMT: 
 * ".https://api.github.com/repos/jukaLang/juka/releases"
 * call for URL to get certain release data 
 * 
 * in certain release data call tag_name to get version
 * 
 * 
 */
        public static string[] getJukaLanguageReleases()
        {
            string data = network.webResParser.fetchWebResAsync("https://api.github.com/repos/jukaLang/juka/releases");
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.Add(
                new ProductInfoHeaderValue("MyApplication", "1"));

            var contents = (JArray)JsonConvert.DeserializeObject(data);
            string[] avaliable_versions = { };
            Console.WriteLine("\n\tCurrent Juka Avaliable Versions: \n");
            foreach (var release in contents)
            {
                var releaseTag = (string)release["tag_name"];
                avaliable_versions.Append<string>(releaseTag);
                Console.WriteLine("\t\t" + releaseTag);
            }
            if (avaliable_versions.Length == 0)
            {
                Console.WriteLine("\n\nThere are no more currently avaliable versions.");
            }
            return avaliable_versions.ToArray();
        }
        public static List<string> getJldnReleases()
        {
            string data = network.webResParser.fetchWebResAsync("https://api.github.com/repos/jukaLang/jldn/releases");
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.Add(
                new ProductInfoHeaderValue("MyApplication", "1"));
            
            var contents = (JArray)JsonConvert.DeserializeObject(data);
            List<string> avaliable_versions = new List<string>();
            Console.WriteLine("\n\tCurrent JLDN Avaliable Versions: \n");
            foreach(var release in contents)
            {
                var releaseTag = (string)release["tag_name"];
                avaliable_versions.Add(releaseTag);
                Console.WriteLine("\t\t"+releaseTag);
            }
            return avaliable_versions;


        }
    }
}
