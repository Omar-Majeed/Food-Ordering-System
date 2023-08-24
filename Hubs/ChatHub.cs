using Microsoft.AspNetCore.SignalR;

namespace SignalR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            //Client.Others 
            //jidhr se invoke huwa us ke ilawa har jgha chala jaye

            //Clients.Caller
            //us ke pass jaye ga jisne call kiya

            await Clients.All.SendAsync("RecieveMessage", message);

            //Receive message function will be made at client end
            //which we are invoking from server side in SendMessage
        }
    }
}
