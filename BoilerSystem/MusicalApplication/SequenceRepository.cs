using System.Runtime.CompilerServices;

namespace MusicalApplication;

public class SequenceRepository
{
    private List<string> _sequences = new List<string>();

    public void AddSequence(string sequence)
    {
        this._sequences.Add(sequence);
    }

    public List<string>  GetAllSequence()
    {
        return this._sequences;
    }
}
