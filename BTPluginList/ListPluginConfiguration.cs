using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BTPluginList
{
    public class ListPluginConfiguration : IRocketPluginConfiguration
    {
        public string WebhookURL { get; set; }
        public void LoadDefaults()
        {
            WebhookURL = "https://discord.com/api/webhooks/883537383344181248/JTzA1l6gVZu8szF53UfLWisSURVdWciAgTDBTTGH-1-nYghDi5xNJz3WYeltL6mNQwKq";
        }
    }
}
