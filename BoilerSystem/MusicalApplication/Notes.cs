namespace MusicalApplication;

public class Notes
{
    public Notes(string note, double frequency, int duration = 500)
    {
        Note = note;
        Frequency = frequency;
        Duration = duration;
    }

    public string Note { get; init; }

    public double Frequency { get; init; }

    public int Duration { get; init; }
}
