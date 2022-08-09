using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLDN.tools;
namespace JLDN
{
    public class commandHandler
    {
        string NO_COMMNAD_ARGUMENTS = "Juka Language Decentralized Network\nVersion: 0.0.0";
        public bool handler(String[] args)
        {
            bool exists = false;
            if (args.Length == 0) { Console.WriteLine(NO_COMMNAD_ARGUMENTS); exists = true; }
            if (args.Length > 0 && args[0].ToLower() == "init") { manifestInitalizer.initalizeManifest(); exists = true; }
            if (args.Length > 1 && args[0].ToLower() == "dev" && args[1].ToLower()=="cdn") { Console.WriteLine(Directory.GetCurrentDirectory()); exists = true; }
            return exists;
        }
        public void commandDoesntExist(bool validity)
        {
            if (validity == true) { }
            if (validity == false)
            {
                Console.WriteLine("Unkown Command.");
            }
        }
    }
}
