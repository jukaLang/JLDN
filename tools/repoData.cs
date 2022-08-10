using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JLDN.tools
{
    public class TREE_DATA
    {
        public string sha { get; set; }
        public string url { get; set; }
        public bool truncated { get; set; }
    }
    public class BLOB_DATA
    {
        public string path { get; set; }
        public string mode { get; set; }
        public string type { get; set; }
        public string sha { get; set; }
        public string url { get; set; }
    }
    internal class repoData
    {
        public static void toJson(dynamic contents)
        {

            foreach (var file in contents)
            {
                var fileType = (string)file["type"];
                if (fileType == "dir")
                {
                    var directoryContentsUrl = (string)file["url"];
                    // use this URL to list the contents of the folder
                    Console.WriteLine($"DIR: {directoryContentsUrl}");
                }
                else if (fileType == "file")
                {
                    var downloadUrl = (string)file["download_url"];
                    // use this URL to download the contents of the file
                    Console.WriteLine($"DOWNLOAD: {downloadUrl}");
                }
            }
        }
        public static void blobList(dynamic data)
        {
            foreach(var file in data)
            {
                var fileType = (string)file["type"];
                if (fileType == "blob")
                {
                    var blobContentsUrl = (string)file["url"];
                    Console.WriteLine($"DIR: {blobContentsUrl}");
                }
            }
        }
        public static dynamic returnRepoFiles(string repoAuthor, string repoName, string repoBranch)
        {
            var repo = String.Format("{0}/{1}", repoAuthor, repoName);
            string url = String.Format("https://api.github.com/repos/{0}/contents", repo);
            dynamic data = JLDN.network.webResParser.fetchWebResAsync(url);
            Console.WriteLine("Web server: Fetching lib contents");

            dynamic jsonData = toJson(data);
            blobList(jsonData);
            return data;

        }
    }
}
