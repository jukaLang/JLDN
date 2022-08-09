using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLDN
{
    internal class commandHandler
    {
        string NO_COMMNAD_ARGUMENTS = "Juka Language Decentralized Network\nVersion: 0.0.0";
        public void handler(String[] args)
        {
            if (args.Length == 0) { Console.WriteLine(NO_COMMNAD_ARGUMENTS); }
        }
    }
}
