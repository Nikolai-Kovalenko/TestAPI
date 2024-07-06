using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;

namespace Client
{
    class Program
    {
        public static string host = "habr.com";

        public static void Main(string[] args)
        {
            Console.WriteLine("start Program");
            Start();
            
        }

        public static void Start()
        {
            try
            {
                //host = "habr.com";
                TcpClient client = new TcpClient();

                client.Connect(host, 80);

                NetworkStream networkStream = client.GetStream();
                networkStream.ReadTimeout = 2000;    

                StringBuilder dataComplier = new StringBuilder();
                dataComplier.AppendLine("GET / HTTP/1.1");
                dataComplier.AppendLine($"Host: {host}");
                dataComplier.AppendLine("Accept: text/html");
                dataComplier.AppendLine("Connection: close");
                dataComplier.AppendLine($"User-Agent: {Assembly.GetExecutingAssembly().GetName().Name}");
                dataComplier.AppendLine("");

                string reuestData = dataComplier.ToString();

                networkStream.Write(Encoding.UTF8.GetBytes(reuestData));
                Console.WriteLine(reuestData);

                var reader = new StreamReader(networkStream, Encoding.UTF8);

                Console.WriteLine("TCP Received: ");
                Console.WriteLine("request: " + reader.ReadToEnd());
                Console.WriteLine();

                reader.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            host = Console.ReadLine().ToString();

            if (host.Length > 0)
            {
                Start();
            }

        }
    }
}
