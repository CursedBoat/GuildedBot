namespace Modules{
    using Guilded;
    using System;
    using System.Reactive.Linq;

    class GeneralModules{
        public static void ResponseCommands(GuildedBotClient client, string prefix){
            client.MessageCreated

                .Where(msgCreated => msgCreated.Content.StartsWith(prefix))
                .Subscribe(async msgCreated =>{

                string afterPrefix = msgCreated.Content.Substring(prefix.Length);
                string[] split = afterPrefix.Split(' ');
                string commandName = split.First();
                string[] args = split.Skip(1).ToArray(); //skips the prefix

                switch(commandName){

                    case "ping":
                        string[] responses = {"You smell go away.", "I took a shit in your pants.", "You're*"};
                        Random rnd = new Random();
                        var _response = responses.GetValue(rnd.Next(0, responses.Count()));
#pragma warning disable CS8600, CS8604
                        string response = Convert.ToString(_response);

                        if (response != null){
                            await msgCreated.ReplyAsync(response);
                        }
                        else{
                            await msgCreated.ReplyAsync("This was not supposed to happen.");
                        }
                        break;

                }

                });
        }
    }
}