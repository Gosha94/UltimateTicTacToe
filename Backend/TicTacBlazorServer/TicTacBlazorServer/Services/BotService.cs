using Microsoft.AspNetCore.SignalR.Client;
using TicTacBlazorServer.Core;

namespace TicTacBlazorServer.Services
{
    public class BotService : BackgroundService
    {
        private readonly ILogger<BotService> _logger;

        private HubConnection _hubConnection;

        public BotService(ILogger<BotService> logger)
        {
            _logger = logger;
        }

        async Task NotifyBot(string[] board, string connectionID)
        {
            GameAlgorithm engine = new GameAlgorithm();
            _logger.LogInformation($"Move received from {connectionID}");
            Move move = engine.GetBestSpot(board, engine.botPlayer);
            board[int.Parse(move.index)] = engine.botPlayer;
            _logger.LogInformation($"Bot Move with the index of {move.index} send to {connectionID}");
            await _hubConnection.InvokeAsync("OnBotMoveReceived", board, connectionID);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/gamehub")
                .Build();
            _hubConnection.On<string[], string>("NotifyBot", NotifyBot);
            await _hubConnection.StartAsync(); // Start the connection.

            //Add to BOT Group When Bot Connected
            await _hubConnection.InvokeAsync("OnBotConnected");
            _logger.LogInformation("Bot connected");

            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

        public async override Task StopAsync(CancellationToken cancellationToken)
        {
            await _hubConnection?.InvokeAsync("OnBotDisconnected");
            _hubConnection?.DisposeAsync();
            _logger.LogInformation("Bot disconnected");
            await base.StopAsync(cancellationToken);
        }

    }
}
