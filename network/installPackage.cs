using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Json;
using YamlDotNet.Serialization;
using System.Collections;
using YamlDotNet.Serialization.NamingConventions;

namespace JLDN.network
{
    public class PACKAGE_INFO
    {
        public string version { get; set; }
        public string package_name { get; set; }
        public string package_description { get; set; }
        public string library_directory { get; set; }
        public string main_repo_branch { get; set; }
        public string repo_name { get; set; }
        public string repo_author_name { get; set; }
    }

        internal class installPackage
    {
            public static void getPackageInfo(string manifest)
            {
                var yaml = @"" + manifest;

            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)  // see height_in_inches in sample yml 
                .Build();

            var p = deserializer.Deserialize<PACKAGE_INFO>(yaml);
            var pn = p.package_name;
            Console.Write(pn);

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
