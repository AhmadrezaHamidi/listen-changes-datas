using Microsoft.AspNetCore.SignalR;
using signalRAh.Domain.Entities;

namespace signalRAh.Infrastructures
{
    public class ScanChanges : BackgroundService
    {
        private readonly IHubContext<HosHub> _hubContext;
        private readonly ILogger<ScanChanges> _logger;
        private readonly IServiceProvider _serviceProvider;
        ///private  ApplicationContext _dbContext ;
        public ScanChanges(IHubContext<HosHub> hubContext, ILogger<ScanChanges> logger, IServiceProvider serviceProvider
        )
        {
            _hubContext = hubContext;
            _logger = logger;
            _serviceProvider = serviceProvider;
            /// _dbContext = dbContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int t = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                t++;
                string res = null;
                using (var scope = _serviceProvider.CreateScope())
                {
                    // var data = _dbContext.SickPersion.ToList();
                    // var res = data[t].Name;



                    var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();


                    var data = context.SickPersion.ToList();
                    res = data[t].Name;

                }



                await _hubContext.newChanges<string>(
                   res);


                await Task.Delay(50, stoppingToken);
            }
        }
    }
}