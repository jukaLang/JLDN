using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Json;
using YamlDotNet.Serialization;
using System.Collections;

namespace JLDN.network
{
    internal class installPackage
    {


            public static void getPackageInfo(string manifest)
            {
                var yaml = @"" + manifest;
                var deserializer = new Deserializer();
                var result = deserializer.Deserialize<List<Hashtable>>(new StringReader(yaml));
                foreach (var item in result)
                {
                    Console.WriteLine("Item:");
                    foreach (DictionaryEntry entry in item)
                    {
                        Console.WriteLine("- {0} = {1}", entry.Key, entry.Value);
                    }
                }
            }
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
                        Console.WriteLine("FS: Creating out directory");
                    }
                    getPackageInfo(manifest);

                }
                catch (IOException ioex)
                {
                    Console.WriteLine(ioex.Message);
                }
            
        }
    }
}
