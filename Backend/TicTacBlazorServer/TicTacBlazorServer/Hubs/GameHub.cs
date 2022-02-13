using Microsoft.AspNetCore.SignalR;

namespace TicTacBlazorServer.Hubs
{
    public class GameHub : Hub
    {
        ILogger<GameHub> _logger;
        private static readonly string BOT_GROUP = "BOT";

        public GameHub(ILogger<GameHub> logger)
        {
            _logger = logger;
        }

        //OnBotConnected - This method gets executed when the bot connected to signalR hub.It also adds the bot client into BOT group.This group is used to communicate with BOT only to send the message with the latest move from the player.
        public async Task OnBotConnected()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, BOT_GROUP);
            _logger.LogInformation("Bot joined");
        }

        //OnBotDisconnected - This method gets executed when the bot disconnected from signalR hub.It also removes the bot from BOT group.
        public async Task OnBotDisconnected()
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, BOT_GROUP);
            _logger.LogInformation("Bot left");
        }


        //OnBotMoveReceived - This method is used to notify the player (caller) after bot finish with the move and ready for the player to respond.
        public async Task OnBotMoveReceived(string[] board, string connectionID)
        {
            await Clients.Client(connectionID).SendAsync("NotifyUser", board);
        }

        //OnUserMoveReceived - This method is used to notify the bot after the player finish with the move and ready for a bot to respond.
        public async Task OnUserMoveReceived(string[] board)
        {
            await Clients.Group(BOT_GROUP).SendAsync("NotifyBot", board, Context.ConnectionId);
        }

    }
}
