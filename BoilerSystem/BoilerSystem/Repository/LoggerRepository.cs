using BoilerSystem.Service;
using static BoilerSystem.Service.Notification;

namespace BoilerSystem.Repository;

/// <summary>
/// Contains operations such as add and view logs.
/// </summary>
public class LoggerRepository
{
    private List<string> _logs = [];

    private readonly CSVWriter _csvWriter;
    private readonly SemaphoreSlim _semaphoreSlim = new (1);

    /// <summary>
    /// Initializes a new instance of the <see cref="LoggerRepository"/> class.
    /// </summary>
    /// <param name="csvWriter"> Instance of csv writer. </param>
    public LoggerRepository(CSVWriter csvWriter)
    {
        this._csvWriter = csvWriter;
    }

    /// <summary>
    /// Adds the log to the file.
    /// </summary>
    /// <param name="log"> Instance of log. </param>
    /// <returns> Task. </returns>
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

    /// <summary>
    /// Loads all log from file into list.
    /// </summary>
    /// <returns> Task. </returns>
    public async Task LoadLogsAsync()
    {
        this._logs = await this._csvWriter.LoadLogsAsync();
    }

    /// <summary>
    /// Gets all log from the list.
    /// </summary>
    /// <returns> List of logs as string. </returns>
    public List<string> GetAllLogs()
    {
        return this._logs;
    }
}