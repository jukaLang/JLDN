using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLDN.tools
{
    internal class cacheFile
    {
        public static string encryptFile(string data)
        {
            byte[] byteList = System.Text.Encoding.UTF8.GetBytes(data);
            string res = System.Text.Encoding.UTF8.GetString(byteList);
            return res;
        }
    }
}
