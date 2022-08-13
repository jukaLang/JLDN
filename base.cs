using System;
using System.Runtime.InteropServices;
using System.Text;
using JLDN;
namespace JLDN
{
    public class CONFIG
    {
        public string CURRENT_VERSION { get; set; }
        public string MAIN_EXE { get; set; }
        public string MAIN_DLL { get; set; }
        public string RELEASE_DATE { get; set; }
    }
    public class CLI
    {

        static void createConfig(string fileName)
        {
            var targetFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\JLDN";
            var currentVersion = JLDN.VERSION_DATA.version;
            var releaseDate = JLDN.VERSION_DATA.releaseDate;
            var mainExe = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            var mainDLL = System.Reflection.Assembly.GetCallingAssembly().Location;

            var config = new CONFIG();

            config.CURRENT_VERSION = currentVersion;
            config.RELEASE_DATE = releaseDate;
            config.MAIN_EXE = mainExe;
            config.MAIN_DLL = mainDLL;
            var dir = targetFolder + "\\" + fileName + ".config.yaml";
            var serializer = new YamlDotNet.Serialization.SerializerBuilder()
                .Build();

            var configRes = serializer.Serialize(config);
            if (Directory.Exists(targetFolder))
            {
                
                if (File.Exists(dir))
                {

                }
                else
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(configRes);
                    using (FileStream fs = File.Create(dir))
                    {
                        fs.Write(info, 0, info.Length);
                        fs.Close();

                    }
                }
            }
            else
            {
                Directory.CreateDirectory(targetFolder);
                byte[] info = new UTF8Encoding(true).GetBytes(configRes);
                using (FileStream fs = File.Create(dir))
                {
                    fs.Write(info, 0, info.Length);
                    fs.Close();
                }
            }
        }

        static void Main(string[] args)
        {
            if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                createConfig("JLDN");
                createConfig("juka");
            }
            JLDN.commandHandler commandHandler = new JLDN.commandHandler();
            bool data = commandHandler.handler(args);
            commandHandler.commandDoesntExist(data);
        }
    }
}

