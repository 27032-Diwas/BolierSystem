using BoilerSystem.Repository;
using static BoilerSystem.Service.Notification;

namespace BoilerSystem.Service;

/// <summary>
/// Contains all logger related operations.
/// </summary>
public class LoggerService
{
    private readonly Notification _notification;
    private readonly LoggerRepository _loggerRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="LoggerService"/> class.
    /// </summary>
    /// <param name="notification"> Instance of notification. </param>
    /// <param name="loggerRepository"> Instance of logger repository. </param>
    public LoggerService(Notification notification, LoggerRepository loggerRepository)
    {
        this._notification = notification;
        this._loggerRepository = loggerRepository;
        this._notification.Notify += this.LogNotification;
    }

    /// <summary>
    /// Adds the log into repository.
    /// </summary>
    /// <param name="sender"> Sender of event. </param>
    /// <param name="args"> Instance of notification. </param>
    public void LogNotification(object? sender, NotificationArgs args)
    {
        _ = this._loggerRepository.AddLogAsync(args);
    }

    /// <summary>
    /// Loads all the logs.
    /// </summary>
    /// <returns> Task. </returns>
    public async Task LoadLogsAsync()
    {
        await this._loggerRepository.LoadLogsAsync();
    }

    /// <summary>
    /// Gets all the logs.
    /// </summary>
    /// <returns> Logs as list of string. </returns>
    public List<string> GetAllLogs()
    {
        return this._loggerRepository.GetAllLogs();
    }
}