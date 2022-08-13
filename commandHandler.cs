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
        string NO_COMMNAD_ARGUMENTS = "Juka Language Decentralized Network\nVersion: " + JLDN.VERSION_DATA.version;

        bool IsNotInArray(String[] array, string element)
        {
            return !Array.Exists(array, e => e == element);
        }
        public bool handler(String[] args)
        {
            try
            {
                bool exists = false;
                if (args.Length == 0) { Console.WriteLine(NO_COMMNAD_ARGUMENTS); exists = true; }
                if (args.Length > 0 && args[0].ToLower() == "init") { manifestInitalizer.initalizeManifest(); exists = true; }
                if (args.Length > 1 && args[0].ToLower() == "dev" && args[1].ToLower() == "cdn") { Console.WriteLine(Directory.GetCurrentDirectory()); exists = true; }
                if (args.Length == 1 && args[0].ToLower() == "help") { JLDN.handler.helpHandler.returnHelp(); exists = true; }
                if (args.Length == 1 && args[0].ToLower() == "info")
                {
                    Console.WriteLine(JLDN.VERSION_DATA.version);
                    Console.WriteLine(JLDN.VERSION_DATA.releaseDate);
                    Console.WriteLine(JLDN.VERSION_DATA.copywrite);
                    exists = true;
                }
                if (args.Length == 1 && args[0].ToLower() == "update" || args[0].ToLower() == "upgrade")
                {
                    List<String> jldnVersions = network.bumpVersion.getJldnReleases();

                    network.bumpVersion.installVersion(network.THIRD_PARTIES.JLDN, jldnVersions[jldnVersions.Count - 1]);

                    exists = true;

                }
                // jldn install REPO_AUTHOR REPO_NAME REPO_BRANCH --FLAG
                if (args.Length >= 3 && args[0].ToLower() == "install")
                {
                    exists = true;
                    try
                    {
                        string manifest = JLDN.network.fetchManifest.fetch(args[1], args[2], args[3]);
                        network.PACKAGE_INFO packageInfo = network.installPackage.getPackageInfo(manifest);
                        tools.repoData.returnRepoFiles(args[1], args[2], args[3], "tools", packageInfo);
                        network.installPackage.installPackageFromManifest(manifest);
                    }
                    catch (System.Net.WebException e)
                    {
                        Console.WriteLine("Error! Package does not exist in the current API");
                    }
                }

                if (args.Length >= 2 && args[0].ToLower() == "bump")
                {
                    if (args[1].ToLower() == "jldn")
                    {
                        if (args[2].Length != 0 || args[2].ToLower() != "latest")
                        {
                            List<String> jldnVersions = network.bumpVersion.getJldnReleases();
                            bool validVersion = jldnVersions.Contains(args[2]);
                            if (validVersion)
                            {
                                Console.WriteLine("\nInstalling Version: " + args[2]);
                                network.bumpVersion.installVersion(network.THIRD_PARTIES.JLDN, args[2]);
                            }
                            else
                            {
                                Console.WriteLine("\nError: Unkown Version");
                                network.bumpVersion.listJldnReleases(jldnVersions);
                            }
                        }
                        else if (args[2].ToLower() != "latest")
                        {
                            List<String> jldnVersions = network.bumpVersion.getJldnReleases();

                            network.bumpVersion.installVersion(network.THIRD_PARTIES.JLDN, jldnVersions[jldnVersions.Count - 1]);
                        }
                    }
                    if (args[1].ToLower() == "juka")
                    {
                        if (args[2].Length != 0)
                        {
                            List<String> jukaVersions = network.bumpVersion.getJukaLanguageReleases();
                            bool validVersion = jukaVersions.Contains(args[2]);
                            if (validVersion)
                            {
                                Console.WriteLine("\nInstalling Version: " + args[2]);
                                network.bumpVersion.installVersion(network.THIRD_PARTIES.juka, args[2]);
                            }
                            else
                            {
                                Console.WriteLine("\nError: Unkown Version");
                                network.bumpVersion.listJukaReleases(jukaVersions);
                            }
                        }
                    }
                    exists = true;

                }
                return exists;

            }
            catch (System.IndexOutOfRangeException e)
            { return true; }

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
