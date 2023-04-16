using LiveStream.Model;
using Newtonsoft.Json;

namespace LiveStream.Services;
public class ChannelServices
{

    private string UrlStream { get; set; }
    public List<StreamChannelModel> StreamModel { get; set; }

    public ChannelServices(string url)
    {
        UrlStream = url;

        StreamModel = GetStreamChannel().Result;
    }

    public async Task<List<StreamChannelModel>> GetStreamChannel()
    {
        try
        {
            using (HttpClient client = new())
            {
                // Send a GET request to the API endpoint to retrieve the JSON data
                var response = await client.GetAsync(UrlStream);
                var jsonString = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON data into a list of Stream objects using JsonConvert.DeserializeObject<T>() method
                List<StreamChannelModel> channelmodel = JsonConvert.DeserializeObject<List<StreamChannelModel>>(jsonString);
                response.EnsureSuccessStatusCode();


                return channelmodel;
            }
        }
        catch (Exception ex)
        {
            return new();
        }

    }
}
