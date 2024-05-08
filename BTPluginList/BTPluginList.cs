using Rocket.API;
using Rocket.Core.Plugins;
using System;
using Logger = Rocket.Core.Logging.Logger;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Rocket.Core;
using System.IO;
using BTPluginList.Helpers;
using ShimmyMySherbet.DiscordWebhooks.Embeded;

namespace BTPluginList
{
    public partial class BTPluginList : RocketPlugin<ListPluginConfiguration>
    {
        public static BTPluginList Instance;
        protected override void Load()
        {
            Instance = this;
            Logger.Log("#############################################", ConsoleColor.Yellow);
            Logger.Log("###          BTPluginList Loaded          ###", ConsoleColor.Yellow);
            Logger.Log("###   Plugin Created By blazethrower320   ###", ConsoleColor.Yellow);
            Logger.Log("###            Join my Discord:           ###", ConsoleColor.Yellow);
            Logger.Log("###     https://discord.gg/YsaXwBSTSm     ###", ConsoleColor.Yellow);
            Logger.Log("#############################################", ConsoleColor.Yellow);

            Level.onLevelLoaded += onLevelLoaded;

        }

        private void onLevelLoaded(int level)
        {
            var files = System.IO.Directory.GetFiles(Directory + @"\..");
            var sb = new StringBuilder();
            foreach (var file in files)
            {
                var fileName = System.IO.Path.GetFileNameWithoutExtension(file);
                if (Configuration.Instance.Restrictions.RestrictedPluginNames.FirstOrDefault(c => c.ToLower().Equals(fileName.ToLower(), StringComparison.CurrentCultureIgnoreCase)) != null)
                    continue;
                sb.AppendLine("> " + fileName);
            }
            var ip = Provider.ip;
            var bytes = BitConverter.GetBytes(ip);
            var serverIP = $"{bytes[0]}.{bytes[1]}.{bytes[2]}.{bytes[3]}";
            ThreadHelper.RunAsynchronously(async () =>
            {
                var embed = new WebhookMessage()
                    .PassEmbed()
                    .WithTitle(Provider.serverName + " Plugin List")
                    .WithColor(EmbedColor.Blue)
                    .WithDescription("**Server IP:** ``" + serverIP + "``\n **Server Port:** ``" + Provider.port + "``\n\n" + sb.ToString()) ;
                embed.footer = new WebhookFooter() { text = "[BTPluginList] " + Provider.serverName + " - " + DateTime.Now.ToString("dddd, dd MMMM yyyy") + "" };
                var send = embed.Finalize();
                await DiscordWebhookService.PostMessageAsync(BTPluginList.Instance.Configuration.Instance.WebhookURL, send);
            });
        }

        protected override void Unload()
        {
            Level.onLevelLoaded -= onLevelLoaded;
            Logger.Log("BTPluginList Unloaded");
            Instance = null;
            base.Unload();
        }
    }
}
