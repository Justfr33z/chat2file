using OQ.MineBot.PluginBase;
using OQ.MineBot.PluginBase.Base.Plugin.Tasks;
using OQ.MineBot.PluginBase.Classes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Chat2File.Tasks {
    public class Chat : ITask {
        private StreamWriter writer;
        private string latestMessage = String.Empty;

        public override bool Exec() => true;

        public async override Task Start() {
            CreateLogFolder();
            writer = new StreamWriter($"{Environment.CurrentDirectory}\\Chat2File\\{Context.Player.GetUsername()}.txt");
            writer.AutoFlush = true;
            Context.Events.onChat += OnChat;
        }

        public async override Task Stop() {
            Context.Events.onChat -= OnChat;
            writer.Close();
        }

        private void OnChat(IBotContext context, IChat chat, byte position) {
            var message = chat.GetText();

            if (message == latestMessage)
                return;

            if (String.IsNullOrWhiteSpace(message))
                return;

            latestMessage = message;

            writer.WriteLine(message);
        }

        private void CreateLogFolder() {
            if (!File.Exists($"{Environment.CurrentDirectory}\\Chat2File"))
                Directory.CreateDirectory($"{Environment.CurrentDirectory}\\Chat2File");
        }
    }
}
