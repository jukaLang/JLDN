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
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            dynamic input = Console.ReadLine();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (String.IsNullOrWhiteSpace(input)) { Console.WriteLine("\nField must not be NULL."); Environment.Exit(0); }
            else
            {
            }
            #pragma warning disable CS8603
            return input;
            #pragma warning restore CS8603
        }
        public static void initalizeManifest()
        {
            string Dir = Directory.GetCurrentDirectory();
            string pkgName = manifestInitalizer.getManifestInfoInput("Package Name: ");
            string pkgDescription = manifestInitalizer.getManifestInfoInput("Package Description: ");
            string libDirectory = manifestInitalizer.getManifestInfoInput("Path to library directory: " + Directory.GetCurrentDirectory().ToString() + "\\");
            string manifestFormat = String.Format(
                "version: 0.0.1"
                +"\npackage_name: {0}"
                +"\npackage_description: {1}"
                + "\nlibrary_directory: \\{2}", pkgName, pkgDescription, libDirectory);
            string path = Dir + "\\" + "manifest.yaml";
            using (FileStream fs = File.Create(path, 1024))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(manifestFormat);
                fs.Write(info, 0, info.Length);
            }


        }
    }
}
