
using Microsoft.AspNetCore.SignalR.Client;

class Program
{
    static async Task Main(string[] args)
    {
        var connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7056/chatHub")
            .Build();

        connection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            Console.WriteLine($"{user}: {message}");
        });

        await connection.StartAsync();
        var user = Console.ReadLine()?.Trim();

        while (true)
        {
            Console.Write("Enter message (or 'exit' to quit): ");
            var message = Console.ReadLine()?.Trim();

            if (message?.ToLower() == "exit")
                break;

            await connection.SendAsync("SendMessage", user, message);
        }

        await connection.DisposeAsync();
    }
}