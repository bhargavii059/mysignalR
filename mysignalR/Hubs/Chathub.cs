using Microsoft.AspNetCore.SignalR;

namespace mysignalR.Hubs
{
    public class Chathub : Hub
    {

        
        public async Task SendMessage(string user, string message)
        {
            
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ReceiveMessage", "System", "A new user has connected.");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("ReceiveMessage", "System", "A user has disconnected.");
            await base.OnDisconnectedAsync(exception);
        }



    }


}
