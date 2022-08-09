using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLDN.tools
{
    internal class argumentChecker
    {
        public static bool validate(String[] args, int baseCommandLength, bool allowFlags)
        {
            bool res = false;
            if(args.Length == baseCommandLength && allowFlags==false)
            {
                res = true;
            }
            if(args.Length == baseCommandLength && allowFlags==true)
            {
                res = true;
            }
            if(args.Length < baseCommandLength)
            {
                Console.WriteLine("No enough arguments supplied");
                res = false;
            }
            return res;
        }
    }
}
