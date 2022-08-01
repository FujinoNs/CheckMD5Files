using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CheckMD5Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Title = "Check MD5 Files by Kroekchai KC (Fujino Ns)";

                if (args.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR Press enter to exit");
                    Console.ReadLine();
                }
                else
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Path: " + args[i]);
                        Console.WriteLine("MD5:");
                        Console.WriteLine(GetMd5(args[i]), Console.ForegroundColor = ConsoleColor.Green);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("=============================================================");
                    }
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static string GetMd5(string fileName)
        {
            string result;
            using (FileStream fileStream = File.OpenRead(fileName))
            {
                MD5 md = new MD5CryptoServiceProvider();
                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte b in md.ComputeHash(fileStream))
                {
                    stringBuilder.Append(b.ToString("x2"));
                }
                result = stringBuilder.ToString();
            }
            return result;
        }
    }
}
