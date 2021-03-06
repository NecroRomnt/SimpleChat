using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SimpleChat.Controllers
{
    public class MessageHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}