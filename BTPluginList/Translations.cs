using Rocket.API.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTPluginList
{
    public partial class BTPluginList
    {
        public override TranslationList DefaultTranslations => new TranslationList
        {
            {
                "ProperUsage", "[color=#FF0000]{{LevelingSystem}} [/color] [color=#F3F3F3]Proper Usage |[/color] [color=#3E65FF]{0}[/color]"
            },

        };
    }
}