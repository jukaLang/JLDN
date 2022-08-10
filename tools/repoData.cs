using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JLDN.tools
{
    internal class repoData
    {
        public static string returnRepoFiles(string repoAuthor, string repoName, string repoBranch)
        {
            string url = "https://api.github.com/repos/jukalang/jldn/git/trees/main?recursive=1";
            //string url = String.Format("https://api.github.com/repos/{0}/{1}/git/trees/{2}?recursive=1", repoAuthor, repoName, repoBranch);
            Console.WriteLine(url);
            string data = JLDN.network.webResParser.fetchWebResAsync(url);
            Console.WriteLine("Web server: Fetching lib contents");
            return data;

        }
    }
}
