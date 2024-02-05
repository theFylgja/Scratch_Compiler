using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace VirtualCI
{
    internal class Program
    {
        static string dir = @"E:\Main\sCompiler\testProj";
        static void Main()
        {
            string cmd = Console.ReadLine();
            if(cmd == null)
            {
                Console.WriteLine("command was null");
                Main();
            }
            string[] cmd_arr = ToStringArray(cmd);
            try
            {
                Console.Write("start");
                Assembly lib = Assembly.LoadFrom(@"C:\VisualStudio\_projects\Scratch_Compiler\SCP_Console\bin\Release\SCP_Console.dll");
                Console.Write(".");
                Type type = lib.GetTypes()[0];
                Console.Write(".");
                var obj = Activator.CreateInstance(type);
                Console.Write(".");
                MethodInfo method = type.GetMethod("Handle");
                Console.WriteLine(".");
                method.Invoke(obj, new object[] { cmd_arr, dir});
            }
            catch(Exception e)
            {
                Console.WriteLine("an error has occured here");
                Console.WriteLine(e.Message);
            }

            Main();
        }
        static string[] ToStringArray(string input)
        {
            List<string> output = new List<string>();

            for(int i = 0; i < input.Length; i++)
            {
                if (input.Substring(i, 1) == " ")
                {
                    output.Add(input.Substring(0, i));
                    input = input.Substring(i + 1);
                    i = 0;
                }
            }
            output.Add(input);
            return output.ToArray();
        }
    }
}
