using System.Net.Security;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
                                                                                                    
                client.Connect(host, 443);

                //NetworkStream networkStream = client.GetStream();
                //networkStream.ReadTimeout = 2000;

                SslStream sslStream = new SslStream(
                    client.GetStream(),
                    false,
                    new RemoteCertificateValidationCallback(ValidateServerCertificate),
                    null
                );

                sslStream.AuthenticateAsClient("");
                sslStream.ReadTimeout = 2000;

                StringBuilder dataComplier = new StringBuilder();
                dataComplier.AppendLine("GET / HTTP/1.1");
                dataComplier.AppendLine($"Host: {host}");
                dataComplier.AppendLine("Accept: text/html");
                dataComplier.AppendLine("Connection: close");
                dataComplier.AppendLine($"User-Agent: {Assembly.GetExecutingAssembly().GetName().Name}");
                dataComplier.AppendLine("");

                string reuestData = dataComplier.ToString();

                sslStream.Write(Encoding.UTF8.GetBytes(reuestData));
                Console.WriteLine(reuestData);

                var reader = new StreamReader(sslStream, Encoding.UTF8);

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

        private static bool ValidateServerCertificate(object sender, X509Certificate certiticate, X509Chain chain, SslPolicyErrors sslPolicy)
        {
            return true;
        }
    }
}
