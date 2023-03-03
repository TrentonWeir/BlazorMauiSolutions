using System.Net;
using System.Linq;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Threading;

namespace IP_Manager
{
    internal class Program
    {
        private static List<Ping> pingers = new();
        List<string> NonActive = new();
        List<string> ActiveIPs= new();
        private static int instances = 0;
        private static object @lock = new();
        private static int result = 0;
        private static int timeout = 250;
        private static int ttl = 5;
        static void Main(string[] args)
        {
            //var ips = GetLocalIPAddresses();
            //foreach(var ip in ips)
            //{
            //    Console.WriteLine(ip);
            //}
            PingIPS();
        }
        static IPAddress[] GetLocalIPAddresses() =>  Dns.GetHostAddresses(Dns.GetHostName());
        static void PingIPS(string baseIP = null)
        {
            if (string.IsNullOrEmpty(baseIP)) baseIP = "192.168.3.";

            Console.WriteLine($"Pinging 255 destinations in {baseIP}");

            CreatePingers(255);

            PingOptions po = new PingOptions(ttl, true);
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            byte[] data = enc.GetBytes("abababababababababababababababab");

            SpinWait wait = new SpinWait();
            int cnt = 1;

            Stopwatch watch = Stopwatch.StartNew();

            foreach (Ping p in pingers)
            {
                lock (@lock)
                {
                    instances += 1;
                }

                p.SendAsync(string.Concat(baseIP, cnt.ToString()), timeout, data, po);
                cnt += 1;
            }

            while (instances > 0)
            {
                wait.SpinOnce();
            }

            watch.Stop();


            Console.WriteLine("Finished in {0}. Found {1} active IP-addresses.", watch.Elapsed.ToString(), result);
            Console.WriteLine($"{(255 / result)}% Full");
            Console.ReadKey();




        }
        public static void Ping_completed(object s, PingCompletedEventArgs e)
        {
            lock (@lock)
            {
                instances -= 1;
            }

            if (e.Reply.Status == IPStatus.Success)
            {
                Console.WriteLine(string.Concat("Active IP: ", e.Reply.Address.ToString()));
                result += 1;
            }
            else
            {
               //Console.WriteLine(string.Concat("Non-active IP: ", e.Reply.Address.ToString()));
            }
        }
        private static void CreatePingers(int cnt)
        {
            for (int i = 1; i <= cnt; i++)
            {
                Ping p = new Ping();
                p.PingCompleted += Ping_completed;
                pingers.Add(p);
            }
        }

    }
}