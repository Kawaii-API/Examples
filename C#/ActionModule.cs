using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace KawaiiAPI_Request_Example
{
    //Creates a new IHostedService.
    public class PrintApiDetails : IHostedService
    {
        public PrintApiDetails(HttpClient client)
        {
            //Sets the HttpClient via DI
            Client = client;
        }

        //Gets the Base HTTClient and inject it into the Class
        public HttpClient Client { get; set; }

        public class KawaiiRedApi
        {
            //Our Json Model which we use to get our response
            [JsonProperty("response")]
            //our Json property
            public string Response { get; set; }
        }

        public async Task<string> HandleWebsiteStringAsync(string main, string actiontype, int[] filters)
        {
            //Our Handle Request gets Created.
            var http = new Chilkat.Http();

            //Sets FollowRedirects to true so we can handle our Request.
            http.FollowRedirects = true;

            //Your Own API Token.
            var kawaii_token = "";

            //The Website which we can modify.
            var website = $"https://kawaii.red/api/{main}/{actiontype}/token={kawaii_token}&filter={filters}";

            //Make the request and get the Redirect page.
            http.QuickGet(website);

            //Check if we got Redirected else return null.
            if (!http.WasRedirected) return null;

            //the actually Redirected website and deserialize the string result.
            var web = await Client.GetFromJsonAsync<KawaiiRedApi>(http.FinalRedirectUrl);

            //Returns the actually Response our end website Link.
            return web?.Response;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            //Create our WebRequest String and print the output.
            var websiteStringAsync = await HandleWebsiteStringAsync("gif", "kiss", new int[] { });

            //prints the output from the string.
            Console.WriteLine(websiteStringAsync);
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
