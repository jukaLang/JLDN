using System;
using System.Runtime.InteropServices;
using JLDN;
namespace JLDN
{
    public class CLI
    {

        static void Main(string[] args)
        {
     
            JLDN.commandHandler commandHandler = new JLDN.commandHandler();
            bool data = commandHandler.handler(args);
            commandHandler.commandDoesntExist(data);
        }
    }
}

