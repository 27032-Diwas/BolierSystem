namespace MusicalApplication;

public class Program
{
    public static void Main()
    {
        SequenceRepository sequenceRepository = new SequenceRepository();
        NotePlayer notePlayer = new NotePlayer(sequenceRepository);
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Add Sequence\n2. Play sequence\n3.Exit");
            string? value = Console.ReadLine();
            int.TryParse(value, out int option);

            if (option == 1)
            {
                notePlayer.GetSequence();
            }
            else if (option == 2)
            {
                notePlayer.PlaySequence();
            }

            if (option == 3)
            {
                break;
            }
        }
    }
}
