    //Our Handle Request gets Created.
    using System;
    using System.Net.Http;
    using System.Net.Http.Json;

    //Make the request and make the actually call.
    using (var client = new HttpClient())
    {
        try
        {
            //Our kawaii API token which we get on https://kawaii.red/dashboard/
            var kawaii_API_token = "";
            
            //Get the Json result from the website
            var response = await client.GetFromJsonAsync<KawaiiRedApi>(
                string.Format("https://kawaii.red/api/gif/{0}/token={1}&filter={2}/", "kiss",
                    kawaii_API_token, new int[] { })
            );

            //check if the response is not null
            if (response is not null)
            {
                // image url
                var imageurl = response.Response
            }
        }
        catch (Exception e)
        {
            //Catches an Exception and print it into the console.
            Console.WriteLine(e);
            throw;
        }
    }