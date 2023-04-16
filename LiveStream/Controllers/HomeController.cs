using LiveStream.Model;
using LiveStream.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Threading.Channels;

namespace LiveStream.Controllers;

[Route("")]
public class HomeController : BaseController
{

    private readonly ChannelServices _channelServices;

    public HomeController(ChannelServices channelServices)
    {
        _channelServices = channelServices;
    }

    [Route("")]
    public IActionResult Index()
    {
        CloudPage();

        List<StreamChannelModel>? Channels = _channelServices.StreamModel.Where(x=>!string.IsNullOrEmpty(x.Name)).ToList();

        return View(Channels);
    }

    [Route("{category}/{channel}")]
    public async Task<IActionResult> Channel(string category,string channel)
    {
        CloudPage(channel);

        StreamChannelModel? stream = _channelServices.StreamModel.FirstOrDefault(x => x.Name == channel);


        return View(stream);
    }


}
