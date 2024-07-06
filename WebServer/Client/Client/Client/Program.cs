using System.Net.Sockets;
using System.Text;
using System.Xml.Serialization;

namespace Client
{
    class Program 
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("start Program");
            Start();
            
        }

        public static void Start()
        {
            try
            {
                string host = "127.0.0.1";
                TcpClient client = new TcpClient();

                client.Connect(host, 7777);

                NetworkStream newtworkStream = client.GetStream();

                var reader = new StreamReader(newtworkStream, Encoding.UTF8);

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

            //Console.ReadKey();

            Start();
        }
    }
}
