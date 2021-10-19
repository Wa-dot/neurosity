using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;




namespace Client
{
    public class Program
    {
        private static Settings settings;
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            var serverUrl = $"ws://{settings.ServerHost}:{settings.ServerPort}/bot";
            var client = new ClientWebSocket();
            //BattleLogger.logger.info($"Connecting to {serverUrl}");
            

            // 2 - Hello message with our GUID

            Guid guid = Guid.NewGuid();
            var bytes = Encoding.UTF8.GetBytes(guid.ToString());
            //BattleLogger.logger.info($"Sending our GUID: {guid}");
            //await client.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
