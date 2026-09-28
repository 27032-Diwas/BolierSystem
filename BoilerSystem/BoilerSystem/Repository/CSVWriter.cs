using System.Text;
using static BoilerSystem.Service.Notification;

namespace BoilerSystem.Repository;

/// <summary>
/// Contains csv read and write operations.
/// </summary>
public class CSVWriter
{
    private readonly string _filePath;

    /// <summary>
    /// Initializes a new instance of the <see cref="CSVWriter"/> class.
    /// </summary>
    /// <param name="filePath"> File path of the log. </param>
    public CSVWriter(string filePath)
    {
        _filePath = filePath;
    }

    /// <summary>
    /// Reads all the logs from the file.
    /// </summary>
    /// <returns> List of logs as string. </returns>
    public async Task<List<string>> LoadLogsAsync()
    {
        List<string> logs = [];

        if (!File.Exists(_filePath))
        {
            return logs;
        }

        using StreamReader reader = new(_filePath);

        await reader.ReadLineAsync();

        string? line;

        while ((line = await reader.ReadLineAsync()) != null)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] values = ParseCsvLine(line);

            logs.Add($"{values[0]}: [{values[1]}] {values[2]}");
        }

        return logs;
    }

    /// <summary>
    /// Writes the log into the file.
    /// </summary>
    /// <param name="logs"> Log to write. </param>
    /// <returns> Task. </returns>
    public async Task WriteLogAsync(NotificationArgs logs)
    {
        bool fileExists = File.Exists(_filePath);

        await using StreamWriter writer = new(_filePath, append: true, encoding: Encoding.UTF8);

        if (!fileExists)
        {
            await writer.WriteLineAsync("TimeStamp,Event,EventMessage");
        }

        string csvRow = $"{logs.TimeStamp}," + $"{EscapeCsv(logs.Event)}," + $"{logs.Message},";

        await writer.WriteLineAsync(csvRow);
    }

    /// <summary>
    /// Convert escape sequence.
    /// </summary>
    /// <param name="value"> Word to convert. </param>
    /// <returns> Converted string. </returns>
    private static string EscapeCsv(string value)
    {
        if (value.Contains(',') || value.Contains('"') || value.Contains('\n'))
        {
            return $"\"{value.Replace("\"", "\"\"")}\"";
        }

        return value;
    }

    /// <summary>
    /// Parse string from reading to string array.
    /// </summary>
    /// <param name="line"> Line read from file. </param>
    /// <returns> Array of string containing each field. </returns>
    private static string[] ParseCsvLine(string line)
    {
        List<string> values = [];
        StringBuilder current = new();

        bool insideQuotes = false;

        foreach (char character in line)
        {
            if (character == '"')
            {
                insideQuotes = !insideQuotes;
            }
            else if (character == ',' && !insideQuotes)
            {
                values.Add(current.ToString());
                current.Clear();
            }
            else
            {
                current.Append(character);
            }
        }

        values.Add(current.ToString());

        return [.. values];
    }
}
