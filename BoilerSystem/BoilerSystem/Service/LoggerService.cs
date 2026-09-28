using BoilerSystem.Repository;
using static BoilerSystem.Service.Notification;

namespace BoilerSystem.Service;

public class LoggerService
{
    private readonly Notification _notification;
    private readonly LoggerRepository _loggerRepository;

    public LoggerService(Notification notification, LoggerRepository loggerRepository)
    {
        this._notification = notification;
        this._loggerRepository = loggerRepository;
        this._notification.Notify += this.LogNotification;
    }

    public void LogNotification(object? sender, NotificationArgs args)
    {
        _ = this._loggerRepository.AddLogAsync(args);
    }

    public async Task LoadLogs()
    {
        await this._loggerRepository.LoadLogsAsync();
    }

    public List<string> GetAllLogs()
    {
        return this._loggerRepository.GetAllLogs();
    }
}
