using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
namespace JLDN.handler
{
    internal class helpHandler
    {
        public static void returnHelp()
        {
            var table = new ConsoleTable("Name", "Usage", "Description", "Flags");
            table.AddRow("install", "jldn install [REPO_AUTHOR] [REPO_NAME] [REPO_BRANCH]", "Installs a package", "NONE");
            table.AddRow("bump ( COMING SOON )", "jldn bump [version]", "Reverts to a previous version", "NONE");
            table.AddRow("info", "jldn info", "Give's your current JLDN and Juka runtime specs", "NONE");

            table.Write(Format.Default);
        }
       }
}
