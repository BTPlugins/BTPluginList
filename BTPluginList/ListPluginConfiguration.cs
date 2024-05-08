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
        public Restrictions Restrictions { get; set; }
        public void LoadDefaults()
        {
            WebhookURL = "https://discordapp.com/api/webhooks/{webhook.id}/{webhook.api}";
            Restrictions = new Restrictions()
            {
                RestrictedPluginNames = new List<string>()
                {
                    "uEssentials",
                    "TPA",
                }
            };
        }
    }
    public class Restrictions
    {
        [XmlArrayItem("PluginName")]
        public List<string> RestrictedPluginNames { get; set; }
    }
}
