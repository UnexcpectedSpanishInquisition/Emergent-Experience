using Discord.Commands;
using Infrastructure;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;


namespace Emergent_Experience.Modules
{
    public class Module1 : ModuleBase<SocketCommandContext>
    {
        private readonly ILogger<Module1> _logger;
        private readonly Servers _servers;

        public Module1(ILogger<Module1> logger, Servers servers)
        {
            _logger = logger;
            _servers = servers;
        }

        [Command("setup")]
        [RequireUserPermission(Discord.GuildPermission.Administrator)]
        public async Task setup(int goalmax = 0, int discoverymax = 0, int bondmax = 0, int setbackmax = 0)
        {
            if (goalmax == 0 && discoverymax == 0 && bondmax == 0 && setbackmax == 0)
            {
                int goalmaxxp = await _servers.SetGoalXp(Context.Guild.Id);
                int discoverymaxxp = await _servers.SetDiscoveryXp(Context.Guild.Id);
                int bondmaxxp = await _servers.SetBondXp(Context.Guild.Id);
                int setbackmaxxp = await _servers.SetSetbackXp(Context.Guild.Id);
                await ReplyAsync($"Goals:0/{goalmaxxp}\nDiscovery:0/{discoverymaxxp}\nBonds:0/{bondmaxxp}\nSetbacks:0/{setbackmaxxp}");
                return;
            }


            int goalxp = await _servers.AddGoalXp(Context.Guild.Id);
            await _servers.ModifyMaxXp(Context.Guild.Id, goalmax, discoverymax, bondmax, setbackmax);
            await ReplyAsync($"Goals:{goalxp}/{goalmax}\nDiscovery:0/{discoverymax}\nBonds:0/{bondmax}\nSetbacks:0/{setbackmax}");
            
        }

               
        [Group(("EE"))]
        public class XpModule : ModuleBase<SocketCommandContext>
        {
            [Group(("Goal"))]
            public class GoalModule : ModuleBase<SocketCommandContext>
            {
                private readonly Servers _servers;
                public GoalModule(Servers servers)
                {
                    _servers = servers;
                }

                [NamedArgumentType]
                public class Integers
                {
                    public int First { get; set; }

                }

                [Command("=")]
                public async Task Eqaul(int goalxp)
                {
                    int goalmaxxp = await _servers.SetGoalXp(Context.Guild.Id);
                    await _servers.AddGoalPoolXp(Context.Guild.Id, goalxp);
                    await ReplyAsync($"Goals:{goalxp}/{goalmaxxp}");
                }

                [Command("+")]
                public async Task Add(int goalxp, params string[] args)
                {
                    if (args.Length == 0 || !int.TryParse(args[0], out int number))
                    {
                        await ReplyAsync("You need to enter a number to add!");
                        return;
                    }
                    goalxp += number;
                    int goalmaxxp = await _servers.SetGoalXp(Context.Guild.Id);
                    await _servers.AddGoalPoolXp(Context.Guild.Id, goalxp);
                    await ReplyAsync($"Goals:{goalxp}/{goalmaxxp}");
                }
            }
        }


        [Command("prefix")]
        [RequireUserPermission(Discord.GuildPermission.Administrator)]
        public async Task Prefix(string prefix = null)
        {
            if (prefix == null)
            {
                var guildPrefix = await _servers.GetGuildPrefix(Context.Guild.Id) ?? "!";
                await ReplyAsync($"The current prefix of this bot = {guildPrefix}");
                return;
            }

            if (prefix.Length > 2)
            {
                await ReplyAsync("The new prefix is too many charcters! (Max 2)");
                return;
            }

            await _servers.ModifyGuildPrefix(Context.Guild.Id, prefix);
            await ReplyAsync($"The prefix has been adjusted to = {prefix} ");
        }

    }

    
}
