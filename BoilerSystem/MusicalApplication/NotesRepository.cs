namespace MusicalApplication;

public static class NotesRepository
{
    public static readonly Dictionary<string, double> Frequencies = new Dictionary<string, double>()
    {
        ["C"] = 261.63,
        ["C#"] = 277.18,
        ["D"] = 293.66,
        ["D#"] = 311.13,
        ["E"] = 329.63,
        ["F"] = 349.23,
        ["F#"] = 369.99,
        ["G"] = 392.00,
        ["G#"] = 451.30,
        ["A"] = 440.00,
        ["A#"] = 466.16,
        ["B"] = 493.88,
    };
}
