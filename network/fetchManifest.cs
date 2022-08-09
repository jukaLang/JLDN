using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLDN.network
{
    internal class fetchManifest
    {
        public static string fetch(string RepoAuthor, string RepoName, string RepoBranch)
        {
            string fetchURL = String.Format("https://raw.githubusercontent.com/{0}/{1}/{2}/manifest.yaml", RepoAuthor, RepoName, RepoBranch);
            string data = JLDN.network.webResParser.fetchWebResAsync(fetchURL);
            Console.WriteLine("Web server: Fetching manifest from server");
            return data;
        }
    }
}
