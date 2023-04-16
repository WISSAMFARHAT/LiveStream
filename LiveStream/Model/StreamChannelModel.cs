using Newtonsoft.Json;

namespace LiveStream.Model;
public class StreamChannelModel
{
    [JsonProperty("channel")]

    public string? Name { get; set; }

    [JsonProperty("url")]

    public string? Url { get; set; }

    [JsonProperty("status")]

    public string? Status { get; set; }

}
