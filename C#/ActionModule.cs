using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Disqord;
using Disqord.Bot;
using Newtonsoft.Json;
using Qmmands;

namespace ProjectName
{
    public class ActionModule : DiscordModuleBase<DiscordGuildCommandContext>
    {
        public HttpClient Client { get; set; }

        public class KawaiiRedAPI
        {
            [JsonProperty("response")]
            public string response { get; set; }
        }
        public async Task<string> HandleWebsiteStringAsync(string actiontype)
        {
            var http = new Chilkat.Http();
            
            http.FollowRedirects = true;

            var apitoken = "token";
            var website = $"http://kawaii.red/api/gif/{actiontype}/token={apitoken}";
            
            http.QuickGet(website);

            if (!http.WasRedirected) return null;
            var web = await Client.GetFromJsonAsync<KawaiiRedAPI>(http.FinalRedirectUrl);

            return web?.response;
        }
        [Command("kill"), Description("Kill somebody")]
        public async Task<DiscordCommandResult> KillApi(IMember member = null)
        {
            if (member is null) return Response("Member not found pls ping a member first.");
            var embed = new LocalEmbed();
            var gif = await HandleWebsiteStringAsync("kill");
            embed.WithImageUrl(gif);
            embed.WithTitle($"{Context.Author.Name} killed {member.Name}");
            return Response(embed);
        }
    }
}