using Microsoft.AspNetCore.SignalR;

namespace signalRAh.Infrastructures
{
    public class HosHub : Hub
    {
    }


    public static class ShipmentsHubExtensions
    {
        public static async Task newChanges<TMessage>(this IHubContext<HosHub> hubContext,
            string messageType,
            CancellationToken cancellationToken = default)
        {
            await hubContext.Clients
                .All
                .SendAsync("newChanges",
                    messageType,
                    cancellationToken);
        }
    }
}