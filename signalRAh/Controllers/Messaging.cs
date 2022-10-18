using MediatR;
using Microsoft.AspNetCore.SignalR;
using signalRAh.Infrastructures;

namespace signalRAh.Controllers
{
    public class CreateThreadMessageCommand : IRequest<string>
    {
        public CreateThreadMessageCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
    public class CreateGroupeMessageCommandHandler : IRequestHandler<CreateThreadMessageCommand, string>
    {
        private readonly IHubContext<HosHub> _hubContext;
        public CreateGroupeMessageCommandHandler(IHubContext<HosHub> hubContext)

        {
            _hubContext = hubContext;

        }

        public async Task<string> Handle(CreateThreadMessageCommand request, CancellationToken cancellationToken)
        {
            await _hubContext.newChanges<string>(
            request.Name);


            return await Task.FromResult(string.Empty);
        }
    }


}