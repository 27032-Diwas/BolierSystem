using System.Security.Cryptography.X509Certificates;

namespace MusicalApplication;

public class NotePlayer
{
    private readonly SequenceRepository _repository;

    public NotePlayer(SequenceRepository repository)
    {
        this._repository = repository;
    }
    public void PlayNote(Notes note)
    {
        Console.Beep((int)note.Frequency, note.Duration);
    }

    public void PlayMusic(List<Notes> notes)
    {
        foreach (Notes note in notes)
        {
            this.PlayNote(note);
        }
    }

    public void GetSequence()
    {
        foreach (var pair in NotesRepository.Frequencies)
        {
            Console.Write($"{pair.Key} ");
        }
        Console.WriteLine();
        Console.WriteLine("Enter your sequence separated by space [C C# A B A#]");
        string? sequence = Console.ReadLine();
        if (sequence is null)
        {
            return;
        }

        this._repository.AddSequence(sequence);
        Console.WriteLine("Sequence added successfully");
    }

    public void PlaySequence()
    {
        List<string> sequences = this._repository.GetAllSequence();

        int i = 1;
        foreach (var sequence in sequences)
        {
            Console.WriteLine($"{i} : {sequence}");
        }

        Console.WriteLine("Enter sequence number:");
        string? seq = Console.ReadLine();
        if (seq is null)
        {
            return;
        }
        int.TryParse(seq, out int value);

        List<Notes> notes = this.ParseNotes(sequences[value - 1]);

        Console.WriteLine("Playing sequence");
        PlayMusic(notes);
    }

    private List<Notes> ParseNotes(string sequence)
    {
        List<Notes> notes = new List<Notes>();

        for (int i = 0; i < sequence.Length; i++)
        {
            if (sequence[i] == ' ')
            {
                continue;
            }

            bool hasNextCharacter = i + 1 < sequence.Length;

            if (hasNextCharacter && sequence[i + 1] == '#')
            {
                string noteName = sequence[i].ToString() + "#";

                if (NotesRepository.Frequencies.ContainsKey(noteName))
                {
                    Notes note = new Notes(noteName, NotesRepository.Frequencies[noteName], 500);

                    notes.Add(note);

                    i++;
                }

                continue;
            }

            string normalNote = sequence[i].ToString();

            if (NotesRepository.Frequencies.ContainsKey(normalNote))
            {
                Notes note = new Notes(normalNote, NotesRepository.Frequencies[normalNote], 200);

                notes.Add(note);
            }
        }

        return notes;
    }
}
