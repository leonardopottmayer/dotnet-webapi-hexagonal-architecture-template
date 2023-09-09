namespace HexagonalArchitecture.Domain.Utils.Logging
{
    public interface ILoggingUtils
    {
        Task<long> Log(LogType type, string message, string? stackTrace);
    }
}
