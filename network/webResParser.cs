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
        public static async Task<string> fetchWebResAsync(string url)
        {
            HttpClient client = new HttpClient();
            string data = await client.GetStringAsync(url);
            return data;
        }
    }
}
