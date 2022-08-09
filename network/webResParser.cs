using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace JLDN.network
{
    internal class webResParser
    {
        public static string fetchWebResAsync(string url)
        {
            System.Net.WebClient client = new System.Net.WebClient();
            byte[] data = client.DownloadData(url);
            String html = System.Text.Encoding.UTF8.GetString(data);
            return html;

        }
    }
}
