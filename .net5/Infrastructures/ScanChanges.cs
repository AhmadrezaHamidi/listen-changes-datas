using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MiladHosSignalR.Domain.Entities;

namespace MiladHosSignalR.Infrastructures
{
    public class ScanChanges : BackgroundService
    {
        private readonly IHubContext<HosHub> _hubContext;
        private readonly ILogger<ScanChanges> _logger;
        private readonly IServiceProvider _serviceProvider;
        public ScanChanges(IHubContext<HosHub> hubContext, ILogger<ScanChanges> logger, IServiceProvider serviceProvider
        )
        {
            _hubContext = hubContext;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int periodeCount = 0;
            while (!stoppingToken.IsCancellationRequested)
            {

                var data = new List<VWSurgeryReception>();
                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

                    if (periodeCount == 0)
                     data = context.VWSurgeryReception.ToList();
                    else
                    {
                        data = context.VWSurgeryReception.OrderByDescending(x => x.SurgeryDate).Skip(10 * periodeCount).ToList();
                    }
                }

                await _hubContext.newChanges<List<VWSurgeryReception>>(
                    data);
                
                
                await Task.Delay(50, stoppingToken);
                periodeCount++;
            }
        }
    }
}
