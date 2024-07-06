using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                IPAddress localAdr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAdr, 7777);

                Console.WriteLine("TCP start");
                server.Start();

                while (true)
                {
                    Console.WriteLine("TCP Wait fir a client");
                    TcpClient client = server.AcceptTcpClient();

                    NetworkStream stream = client.GetStream();

                    string response = "Hello form the server";
                    byte[] data = Encoding.UTF8.GetBytes(response);

                    stream.Write(data, 0, data.Length);
                    Console.WriteLine($"Send: {response}");

                    stream.Close();
                    client.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (server != null)
                {
                    server.Stop();
                }
            }
        }
    }
}

