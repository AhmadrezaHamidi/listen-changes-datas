using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using MiladHosSignalR.Domain.Entities;

namespace MiladHosSignalR.Infrastructures
{
    public class HosHub : Hub
    {
    }


    public static class ShipmentsHubExtensions
    {
        public static async Task newChanges<TMessage>(this IHubContext<HosHub> hubContext,
            List<VWSurgeryReception> data,
            CancellationToken cancellationToken = default)
        {
            await hubContext.Clients
                .All
                .SendAsync("newChanges",
                    data,
                    cancellationToken);
        }
    }
}
