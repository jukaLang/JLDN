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
            public static PACKAGE_INFO getPackageInfo(string manifest)
            {
                var yaml = @"" + manifest;
                
                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(UnderscoredNamingConvention.Instance)  // see height_in_inches in sample yml 
                    .Build();

            var p = deserializer.Deserialize<PACKAGE_INFO>(yaml);
            Console.WriteLine("JLDN: Installing " + p.package_name + " @" + p.version);
            Console.WriteLine("GitServer: Package LOC format [" + p.repo_author_name + "\\" + p.repo_name + "@" + p.main_repo_branch+"]");
            return p;
        }
        public static void CreateCacheFileForModule(PACKAGE_INFO package)
        {
            string path = Directory.GetCurrentDirectory() + "\\juka_modules\\"+package.package_name+".jukc";
            Console.WriteLine("FS: Writing Cached LIB file");
            using (FileStream fs = File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(JLDN.tools.cacheFile.encryptFile("safasf"));

                fs.Write(info, 0, info.Length);
                Console.WriteLine(String.Format("\n\nSucessfuly Installed: {0}@{1}", package.package_name, package.version));
            }

        }

        public static void CreateFileForModule(PACKAGE_INFO package, string fileName, dynamic content, string relativeDirectory)
        {
            string path = Directory.GetCurrentDirectory() + "\\juka_modules\\" + package.package_name + relativeDirectory;

            if(Directory.Exists(path))
            {
                using (FileStream fs = File.Create(path + "\\" + fileName))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(JLDN.tools.cacheFile.encryptFile(content));
                    fs.Write(info, 0, info.Length);

                }
            }
            else
            {
                Directory.CreateDirectory(path);
                using (FileStream fs = File.Create(path + "\\" + fileName))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(JLDN.tools.cacheFile.encryptFile(content));
                    fs.Write(info, 0, info.Length);

                }
            }
        }

        public static void CreateSubfolderForModule(PACKAGE_INFO package, string folderName)
        {
            string path = Directory.GetCurrentDirectory() + "\\juka_modules\\" + package.package_name + folderName;
            if (Directory.Exists(path)) { return; } 
            else { Directory.CreateDirectory(path); }
        }

        public static void installFlags(String[] args)
        {
            bool isFlags = false;
            if(args.Length >= 4) isFlags = true;
            List<string> allowedFlags = new List<string>
            {
                "--info",
                "-i"
            };


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
                    PACKAGE_INFO info = getPackageInfo(manifest);
                    CreateCacheFileForModule(info);

                }
                catch (IOException ioex)
                {
                    Console.WriteLine(ioex.Message);
                }
            }
        }
    }
