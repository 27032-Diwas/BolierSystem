using BoilerSystem.Enums;

namespace BoilerSystem.Models;

public class Boiler
{
    public Boiler(BoilerState state, InterLockSwitch interlockSwitch, BoilerSequence sequence)
    {
        this.State = state;
        this.Switch = interlockSwitch;
        this.Sequence = sequence;
    }

    public BoilerState State { get; set; }

    public InterLockSwitch Switch { get; set; }

    public BoilerSequence Sequence { get; set; }

    public TimeSpan RemainingTime { get; set; }

    public DateTime EndTime { get; set; }
}
