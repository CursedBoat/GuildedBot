using System;
using System.Reactive.Linq;
using Guilded;
using Newtonsoft.Json.Linq;
using static Modules.GeneralModules;

namespace MainProgram{
    class Program{

        static async Task Main(){
            JObject config = JObject.Parse(await File.ReadAllTextAsync("./config/config.json"));

            string auth = config.Value<string>("auth")!,
                prefix = config.Value<string>("prefix")!;

            using GuildedBotClient client = new(auth);
            
            client.Prepared
            .Subscribe(me =>
                Console.WriteLine("The bot is prepared!\nLogged in as \"{0}\" with the ID \"{1}\"", me.Name, me.Id)
            );

            ResponseCommands(client, prefix); //running the command module, which is being done explicitly rn but will be changed to check for more classes and methods automatically
            
            RunAsync(client).GetAwaiter().GetResult();
        }

        static async Task RunAsync(GuildedBotClient client)
        {
            await client.ConnectAsync().ConfigureAwait(false);
            await Task.Delay(-1);
        }
    }
}