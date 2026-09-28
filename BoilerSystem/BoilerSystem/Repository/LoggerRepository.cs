using BoilerSystem.Service;
using static BoilerSystem.Service.Notification;

namespace BoilerSystem.Repository;

public class LoggerRepository
{
    private List<string> _logs = new ();

    private readonly CSVWriter _csvWriter;
    private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim (1);

    public LoggerRepository(CSVWriter csvWriter)
    {
        this._csvWriter = csvWriter;
    }
    public async Task AddLogAsync(NotificationArgs log)
    {
        try
        {
            await this._semaphoreSlim.WaitAsync();
            this._logs.Add($"{log.TimeStamp}: [{log.Event}] {log.Message}");
            await this._csvWriter.WriteLogAsync(log);
        }
        finally
        {
            this._semaphoreSlim.Release();
        }
    }

    public async Task LoadLogsAsync()
    {
        this._logs = await this._csvWriter.LoadLogsAsync();
    }

    public List<string> GetAllLogs()
    {
        return this._logs;
    }
}
