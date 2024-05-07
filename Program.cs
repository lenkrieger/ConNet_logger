using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;

namespace ConnectionTester
{
    class Program
    {
        static string filename = "connection_log.txt";

        static void Main(string[] args)
        {
            while (true)
            {
                Ping ping = new Ping();
                try
                {
                    DateTime now = DateTime.Now;
                    PingReply reply = ping.Send("google.com");
                    if (reply.Status == IPStatus.Success)
                    {
                        Console.WriteLine("Connection is OK " + now.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Connection lost at " + now.ToString());
                        using (StreamWriter file = new StreamWriter(filename, true))
                        {
                            file.WriteLine(now.ToString());
                        }
                    }
                }
                catch (PingException ex)
                {
                    DateTime now = DateTime.Now;
                    Console.WriteLine("Connection lost at " + now.ToString());
                    using (StreamWriter file = new StreamWriter(filename, true))
                    {
                        file.WriteLine(now.ToString());
                    }
                }
                Thread.Sleep(10000);
            }
        }
    }
}
