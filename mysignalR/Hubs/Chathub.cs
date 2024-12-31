using Microsoft.AspNetCore.SignalR;

namespace mysignalR.Hubs
{
    public class Chathub : Hub
    {

        // This method will be called from the client-side to send a message.
        public async Task SendMessage(string user, string message)
        {
            // Sends the message to all connected clients (broadcasts to all users).
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        // Optionally, you can add client-side connection management methods
        public override async Task OnConnectedAsync()
        {
            // For example, you can broadcast a notification when a user joins
            await Clients.All.SendAsync("ReceiveMessage", "System", "A new user has connected.");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Optionally, broadcast a notification when a user disconnects
            await Clients.All.SendAsync("ReceiveMessage", "System", "A user has disconnected.");
            await base.OnDisconnectedAsync(exception);
        }



    }


}
