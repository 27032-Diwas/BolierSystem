namespace BoilerSystem.Enums;

public enum BoilerSequence
{
    /// <summary>
    /// Represent the idle state of boiler.
    /// </summary>
    Idle,

    /// <summary>
    /// Represents the pre purge state in boiler sequence.
    /// </summary>
    PrePurge,

    /// <summary>
    /// Represents the ignition state in boiler sequence.
    /// </summary>
    Ignition,

    /// <summary>
    /// Represents the operational state in boiler sequence.
    /// </summary>
    Operational,
}