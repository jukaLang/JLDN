using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace JLDN.network
{
    enum THIRD_PARTIES
    { 
        juka,
        JLDN
    }
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
        public static List<string> getJukaLanguageReleases()
        {
            string data = network.webResParser.fetchWebResAsync("https://api.github.com/repos/jukaLang/juka/releases");
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.Add(
                new ProductInfoHeaderValue("MyApplication", "1"));

            var contents = (JArray)JsonConvert.DeserializeObject(data);
            List<string> avaliable_versions = new List<string>();
            foreach (var release in contents)
            {
                var releaseTag = (string)release["tag_name"];
                avaliable_versions.Add(releaseTag);
            }
            return avaliable_versions;
        }
        public static List<string> getJldnReleases()
        {
            string data = network.webResParser.fetchWebResAsync("https://api.github.com/repos/jukaLang/jldn/releases");
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.Add(
                new ProductInfoHeaderValue("MyApplication", "1"));
            
            var contents = (JArray)JsonConvert.DeserializeObject(data);
            List<string> avaliable_versions = new List<string>();
            foreach(var release in contents)
            {
                var releaseTag = (string)release["tag_name"];
                avaliable_versions.Add(releaseTag);
            }
            return avaliable_versions;
        }

        public static void listJldnReleases(List<string> data)
        {
            Console.WriteLine("\nCurrent JLDN Avaliable Versions: \n");
            foreach(var version in data)
            {
                Console.WriteLine("\t - " + version);
            }
        }
        public static void listJukaReleases(List<string> data)
        {
            Console.WriteLine("\nCurrent Juka Avaliable Versions: \n");
            foreach (var version in data)
            {
                Console.WriteLine("\t - " + version);
            }
        }
        
        public static CONFIG deserializeConfig(dynamic data)
        {
            JLDN.CONFIG config = new JLDN.CONFIG();
            var deserializer = new DeserializerBuilder()
                .Build();
            return deserializer.Deserialize<CONFIG>(data);
        }
        public static string getConfigData()
        {
            var targetFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\JLDN";
            var configFile = "config.yaml";
            var path = targetFolder + "\\" + configFile;
            return File.ReadAllText(@"" + path, Encoding.UTF8);
        }

        public static void installVersion(THIRD_PARTIES service, string targetVersion)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {

                // INSTAL JUKA
                if (service == THIRD_PARTIES.juka)
                {
                    var targetFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\JLDN";
                    var configFile = "config.yaml";
                    var path = targetFolder + "\\" + configFile;
                    var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                    using(var reader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        string text = reader.ReadToEnd();
                        var data = deserializeConfig(text);
                        data.CURRENT_VERSION = targetVersion;
                        Console.WriteLine(data.CURRENT_VERSION);
                    }

                }
                // INSTALL JLDN
                if (service == THIRD_PARTIES.JLDN) { }
            }
            else
            {
                Console.WriteLine("Sorry. JLDN 'bump' function is only avaliable on the windows operating system in this version.");
            }

        }
    }
}
