using Chat2File.Tasks;
using OQ.MineBot.PluginBase.Base;
using OQ.MineBot.PluginBase.Base.Plugin;
using OQ.MineBot.PluginBase.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat2File {
    [Plugin(2, "Chat2File", "Saves the chat of each bot into a text file")]
    public class PluginCore : IStartPlugin {
        public override void OnLoad(int version, int subversion, int buildversion) { }

        public override PluginResponse OnEnable(IBotSettings botSettings) {
            if (!botSettings.loadChat) {
                Console.WriteLine("'Load chat' must be enabled.");
                return new PluginResponse(false, "'Load chat' must be enabled.");
            }

            return new PluginResponse(true);
        }

        public override void OnStart() {
            RegisterTask(new Chat());
        }
    }
}
