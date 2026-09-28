using System.Text;
using static BoilerSystem.Service.Notification;

namespace BoilerSystem.Repository;

public class CSVWriter
{
    private readonly string _filePath;

    public CSVWriter(string filePath)
    {
        _filePath = filePath;
    }

    public async Task<List<string>> LoadLogsAsync()
    {
        List<string> logs = new();

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

    private static string EscapeCsv(string value)
    {
        if (value.Contains(',') || value.Contains('"') || value.Contains('\n'))
        {
            return $"\"{value.Replace("\"", "\"\"")}\"";
        }

        return value;
    }

    private static string[] ParseCsvLine(string line)
    {
        List<string> values = new();
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

        return values.ToArray();
    }
}
