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
            if (String.IsNullOrWhiteSpace(input)) { Console.WriteLine("\nField must not be NULL."); res = false; Environment.Exit(0); }
            else
            {
                res = true;
            }
            return input;
        }
        public static void initalizeManifest()
        {
            string Dir = Directory.GetCurrentDirectory();
            string pkgName = manifestInitalizer.getManifestInfoInput("Package Name: ");
            string pkgDescription = manifestInitalizer.getManifestInfoInput("Package Description: ");
            string libDirectory = manifestInitalizer.getManifestInfoInput("Path to library directory: " + Directory.GetCurrentDirectory().ToString() + "\\");
            string manifestFormat = String.Format("version: 0.0.1\npackage_name: {0}\npackage_description: {1}\nlibrary_directory: \\{2}", pkgName, pkgDescription, libDirectory);
            Console.WriteLine(manifestFormat);
        }
    }
}
