using System;
namespace JLDN
{
    public class CLI
    {

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("JLDN Version 0.0.001");
            }
            if (args.Length >= 0 && args[1]=="help")
            {
                Console.WriteLine("Help Command Called");
            }
        }
    }
}

