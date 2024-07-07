using System.Collections.Concurrent;
using Microsoft.AspNetCore.SignalR.Client;

namespace WSClient
{
    class Program
    {
        private static HubConnection _connection;

        async static Task Main(string[] args)
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5236/notification")
                .WithAutomaticReconnect()
                .Build();

            _connection.On<string>("ReciveMassage", (massage) =>
            {
                var newMessage = $"{DateTime.Now.ToShortTimeString()}: {massage}";
                Console.WriteLine(newMessage);
            });

            try
            {
                await _connection.StartAsync();
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
                    var massage = Console.ReadLine().ToString();
                    await _connection.InvokeAsync("SendMassageToAllUser", massage);
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
