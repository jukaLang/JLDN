using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLDN.network
{
    internal class installPackage
    {
        public static void installPackageFromManifest(string manifest)
        {
            string path = Directory.GetCurrentDirectory() + "\\juka_modules";

            // CREATES juka_modules FOLDER
            try
            {
                Console.WriteLine("FS: Checking if o directory exists");

                if (!Directory.Exists(path))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    Console.WriteLine("FS: Creating o directory");
                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine(ioex.Message);
            }
        }
    }
}
