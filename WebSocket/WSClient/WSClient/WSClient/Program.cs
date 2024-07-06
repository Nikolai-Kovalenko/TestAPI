using System.Collections.Concurrent;
using Microsoft.AspNetCore.SignalR.Client;

namespace WSClient
{
    class Program
    {
        private static HubConnection connection;

        async static Task Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localchost:5000/notification")
                .WithAutomaticReconnect()
                .Build();

            connection.On<string>("ReciveMassage", (massage) =>
            {
                var newMessage = $"{DateTime.Now.ToShortTimeString()}: {massage}";
                Console.WriteLine(newMessage);
            });

            try
            {
                await connection.StartAsync();
                Console.WriteLine("Connection Started");
                await waitForMassage();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        private async static Task waitForMassage()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("You say: ");
                    var massage = Console.ReadLine();
                    await connection.InvokeAsync("SendMassageToAllUser", massage);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    throw;
                }
            }
        }
    }
}
