using BoilerSystem.Enums;

namespace BoilerSystem.Models;

/// <summary>
/// Contains all properties of boiler.
/// </summary>
public class Boiler
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Boiler"/> class.
    /// </summary>
    /// <param name="state"> State of the boiler. </param>
    /// <param name="interlockSwitch"> State of interlock switch. </param>
    /// <param name="sequence"> State of the boiler sequence. </param>
    public Boiler(BoilerState state, InterLockSwitch interlockSwitch, BoilerSequence sequence)
    {
        this.State = state;
        this.Switch = interlockSwitch;
        this.Sequence = sequence;
    }

    /// <summary>
    /// Gets or sets boiler state.
    /// </summary>
    /// <value> Boiler state. </value>
    public BoilerState State { get; set; }

    /// <summary>
    /// Gets or sets interlock switch state.
    /// </summary>
    /// <value> Interlock switch. </value>
    public InterLockSwitch Switch { get; set; }

    /// <summary>
    /// Gets or sets boiler sequence.
    /// </summary>
    /// <value> Boiler sequence. </value>
    public BoilerSequence Sequence { get; set; }

    /// <summary>
    /// Gets or sets remaining time in boiling sequence.
    /// </summary>
    /// <value> Remaining time in boiler sequence. </value>
    public TimeSpan RemainingTime { get; set; }

    /// <summary>
    /// Gets or sets end time of current phase in boiler sequence.
    /// </summary>
    /// <value> End time of current phase. </value>
    public DateTime EndTime { get; set; }
}