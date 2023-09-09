using HexagonalArchitecture.Domain.Adapters.UserProvider;
using HexagonalArchitecture.Domain.Models.SystemLogModels;
using HexagonalArchitecture.Domain.Utils.Logging;
using HexagonalArchitecture.Logic.Cqrs.SystemLogCqrs.Definitions.Crud;
using MediatR;

namespace HexagonalArchitecture.Logic.Utils.Logging
{
    internal class LogginInfo
    {
        public long UserId { get; set; }
        public long UnixTimestamp { get; set; }
        public DateTimeOffset Date { get; set; }
        public LogType Type { get; set; }
        public string? StackTrace { get; set; }

        public LogginInfo(long userId, long unixTimestamp, DateTimeOffset date, LogType type, string? stackTrace)
        {
            UserId = userId;
            UnixTimestamp = unixTimestamp;
            Date = date;
            Type = type;
            StackTrace = stackTrace;
        }
    }

    public class LoggingUtils : ILoggingUtils
    {
        private readonly IUserReference _userReference;
        private readonly IMediator _mediator;

        public LoggingUtils(IUserReference userReference, IMediator mediator)
        {
            _userReference = userReference;
            _mediator = mediator;
        }

        public async Task<long> Log(LogType type, string message, string? stackTrace)
        {
            var loggingInfo = MountLoggingInfo(type, stackTrace);

            return await LogToDatabase(loggingInfo, message);
        }

        private LogginInfo MountLoggingInfo(LogType logType, string? stackTrace)
        {
            return new LogginInfo(_userReference.User != null ? _userReference.User.Id : 0, DateTimeOffset.Now.ToUnixTimeMilliseconds(), DateTimeOffset.Now, logType, stackTrace);
        }

        private async Task<long> LogToDatabase(LogginInfo loggingInfo, string message)
        {
            var createSystemLogCmd = new CreateSystemLogCommand()
            {
                SystemLog = new CreateSystemLogDto()
                {
                    Date = loggingInfo.Date,
                    Message = message,
                    Type = Enum.GetName(typeof(LogType), loggingInfo.Type),
                    UserId = loggingInfo.UserId,
                    StackTrace = loggingInfo.StackTrace
                }
            };

            var createSystemLogCmdResult = await _mediator.Send(createSystemLogCmd);
            return createSystemLogCmdResult;
        }
    }
}
