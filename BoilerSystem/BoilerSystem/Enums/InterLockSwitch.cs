using System.ComponentModel.DataAnnotations;

namespace BoilerSystem.Enums;

public enum InterLockSwitch
{
    /// <summary>
    /// Represents the open state of interlock switch.
    /// </summary>
    [Display (Name = "Open")]
    Open = 1,

    /// <summary>
    /// Represents the close state of interlock switch.
    /// </summary>
    [Display (Name = "Close")]
    Close,
}
