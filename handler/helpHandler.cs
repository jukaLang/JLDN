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
            table.AddRow("bump", "jldn bump [SERVICE] [VERSION]", "Reverts to a previous version", "\"latest\" -\t Replace [ VERSION ] with \"latest\" and it will install the newest version");
            table.AddRow("info", "jldn info", "Give's your current JLDN and Juka runtime specs", "NONE");
            table.AddRow("update/upgrade", "jldn update/upgrade", "Updates JLDN's version to the latest", "NONE");

            table.Write(Format.Default);
        }
       }
}
