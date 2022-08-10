﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
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
        public static async void returnRepoFiles(string repoAuthor, string repoName, string repoBranch, string libFolder)
        {
            Console.WriteLine("Fetching REPO");
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.Add(
                new ProductInfoHeaderValue("MyApplication", "1"));
            Console.WriteLine("Net: HTTP User Agent Header Established");

            var repo = String.Format("{0}/{1}", repoAuthor, repoName);
            var contentsUrl = String.Format("https://api.github.com/repos/{0}/contents", repo);

            var contentsJson = network.webResParser.fetchWebResAsync(contentsUrl);
            var contents = (JArray)JsonConvert.DeserializeObject(contentsJson);


            foreach (var file in contents)
            {
                var fileType = (string)file["type"];
                if (fileType == "dir")
                {
                    var folders = (string)file["path"];
                    //Console.WriteLine(folders);
                    // use this URL to list the contents of the folder
                    Console.WriteLine(libFolder);
                    if (folders ==libFolder)
                    {
                        Console.WriteLine("DIR: " + folders);
                    }
                    else
                    {
                        Console.WriteLine("Error: Manifest file library directory doesn't match.");
                    }
                }
                //else if (fileType == "file")
                //{
                //    var downloadUrl = (string)file["download_url"];
                //    // use this URL to download the contents of the file
                //    Console.WriteLine($"DOWNLOAD: {downloadUrl}");
                //}
            }

        }
    }
}
