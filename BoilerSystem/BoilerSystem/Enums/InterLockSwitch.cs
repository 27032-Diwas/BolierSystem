using System.ComponentModel.DataAnnotations;

namespace BoilerSystem.Enums;

public enum InterLockSwitch
{
    [Display (Name = "Open")]
    Open = 1,

    [Display (Name = "Close")]
    Close,
}
