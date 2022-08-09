using System;
namespace JLDN
{
    public class CLI
    {

        static void Main(string[] args)
        {
            for ( int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(i +": "+ args[i]);
            }
        }
    }
}

