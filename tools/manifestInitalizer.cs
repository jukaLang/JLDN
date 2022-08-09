using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLDN.tools
{
    internal class manifestInitalizer
    {
        public static string getManifestInfoInput(string Prompt)
        {

            Console.Write(Prompt);
            dynamic input = Console.ReadLine();
            bool res = false;
            if (String.IsNullOrWhiteSpace(input)) { Console.WriteLine("Project name must not be NULL."); res = false; Environment.Exit(0); }
            else
            {
                res = true;
            }
            return input;
        }
        public static void initalizeManifest()
        {
            string Dir = Directory.GetCurrentDirectory();
            string prjName = manifestInitalizer.getManifestInfoInput("Project Name: ");
            string pkgName = manifestInitalizer.getManifestInfoInput("Package Name: ");
            string pkgDescription = manifestInitalizer.getManifestInfoInput("Package Description: ");
            string libDirectory = manifestInitalizer.getManifestInfoInput("Path to library directory: " + Directory.GetCurrentDirectory().ToString() + "\\");


        }
    }
}
