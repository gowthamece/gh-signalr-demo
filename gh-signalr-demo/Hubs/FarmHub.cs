using gh_signalr_demo.Models;
using Microsoft.AspNetCore.SignalR;

namespace gh_signalr_demo.Hubs
{
    public class FarmHub: Microsoft.AspNetCore.SignalR.Hub 
    {
        public async Task NotifyNewTemperature(TemperatureNotify auction)
        {
            await Clients.All.SendAsync("ReceiveNewTemperature", auction);
        }
    }
}
