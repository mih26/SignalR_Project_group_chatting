using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace WebApplication1.Hubs
{
    public class MessageHub : Hub
    {
        private static Dictionary<string, string> users = new Dictionary<string, string>();
        public static List<string> groups = new List<string> { "SignalR", "Blazor", "Angular" };
        public async override Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("connected", "You are connected");
        }
        public async Task AddMe(string name)
        {

            users.Add(Context.ConnectionId, name);
            await Clients.Caller.SendAsync("Added", "You are added");
            await Clients.All.SendAsync("grouplist", groups);

        }
        public async Task Join(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
            await Clients.All.SendAsync("userlist", users.Values.ToArray());
        }
        public async Task Create(string group)
        {
            groups.Add(group);
            await Clients.All.SendAsync("grouplist", groups);
        }
        public async Task Send(string group, string msg)
        {
            await Clients.Groups(group).SendAsync("recieveMessage", users[Context.ConnectionId], msg);
        }
        public async override Task OnDisconnectedAsync(Exception? exception)
        {

            users.Remove(Context.ConnectionId);
            await Task.CompletedTask;
        }
    }
}
