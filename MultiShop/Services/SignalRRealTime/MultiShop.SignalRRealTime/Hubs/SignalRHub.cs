using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRRealTime.Services.SignalRCommentServices;
using MultiShop.SignalRRealTime.Services.SignalRMessageServices;
using MultiShop.WebUI.Services.Interface;

namespace MultiShop.SignalRRealTime.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalRCommentService _signalRCommentService;

        public SignalRHub(ISignalRCommentService signalRCommentService)
        {
            _signalRCommentService = signalRCommentService;
            
        }

        public async Task SendStatisticCount()
        {
            
            var getTotalComment = await _signalRCommentService.GetTotalCommentCount();
            await Clients.All.SendAsync("ReceiveCommentCount",getTotalComment);

        }
    }
}
