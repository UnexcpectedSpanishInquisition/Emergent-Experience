﻿using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.Addons.Hosting;
using Discord.Commands;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Emergent_Experience.Services;

namespace Emergent_Experience
{
    class Program
    {
     static async Task Main()
        {
            var builder = new HostBuilder()
                .ConfigureAppConfiguration(x =>
                {
                    var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", false, true)
                        .Build();

                    x.AddConfiguration(configuration);

                })
               .ConfigureLogging(x =>
               {
                   x.AddConsole();
                   x.SetMinimumLevel(LogLevel.Debug);
               })
               .ConfigureDiscordHost<DiscordSocketClient>((context, config) =>
               {
                   config.SocketConfig = new DiscordSocketConfig
                   {
                       LogLevel = LogSeverity.Verbose,
                       AlwaysDownloadUsers = true,
                       MessageCacheSize = 200,
                   };

                   config.Token = context.Configuration["token"];
               })
               .UseCommandService((context, config) =>
               {
                   config = new CommandServiceConfig()
                   {
                       CaseSensitiveCommands = false,
                       LogLevel = LogSeverity.Verbose

                   };
               })
               .ConfigureServices((context, services) =>
               {
                   services
                   .AddHostedService<CommandHandler>()
                   .AddDbContext<ServerContext>()
                   .AddSingleton<Servers>();

               })
               .UseConsoleLifetime();

            var host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}
