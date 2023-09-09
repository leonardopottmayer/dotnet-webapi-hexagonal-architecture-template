using HexagonalArchitecture.Adapter.SystemInfoProvider.Models;
using HexagonalArchitecture.Domain.Adapters.SystemInfoProvider;
using HexagonalArchitecture.Logic.Cqrs.SystemMessageCqrs.Definitions.Crud;
using HexagonalArchitecture.Logic.Cqrs.SystemParameterCqrs.Definitions.Crud;
using MediatR;

namespace HexagonalArchitecture.Adapter.SystemInfoProvider
{
    public class SystemInfoReference : ISystemInfoReference
    {
        private readonly IMediator _mediator;
        public ISystemParameterReferenceData SystemParameters { get; private set; }
        public ISystemMessageReferenceData SystemMessages { get; private set; }

        public SystemInfoReference(IMediator mediator)
        {
            _mediator = mediator;

            CreateSystemInfo();
        }

        /// <summary>
        /// Queries system parameters and system messages
        /// </summary>
        private async void CreateSystemInfo()
        {
            // Get parameters
            var getAllSystemParametersCmd = new GetAllSystemParametersCommand() { };
            var getAllSystemParametersCmdResult = await _mediator.Send(getAllSystemParametersCmd);

            var systemParameterReferenceData = new SystemParameterReferenceData(getAllSystemParametersCmdResult);
            SystemParameters = systemParameterReferenceData;

            // Get messages
            var getAllSystemMessagesCmd = new GetAllSystemMessagesCommand() { };
            var getAllSystemMessagesCmdResult = await _mediator.Send(getAllSystemMessagesCmd);

            var systemMessageReferenceData = new SystemMessageReferenceData(getAllSystemMessagesCmdResult);
            SystemMessages = systemMessageReferenceData;
        }
    }
}
