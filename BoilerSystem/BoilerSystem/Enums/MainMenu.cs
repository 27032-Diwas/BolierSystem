using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace BoilerSystem.Enums;

public enum MainMenu
{
    [Display (Name = "Exit the Application")]
    Exit,

    [Display (Name = "Start Boiler Sequence")]
    Start,

    [Display (Name = "Stop Boiler Sequence")]
    Stop,

    [Display (Name = "Toggle Interlock Switch")]
    ToggleInterLock,

    [Display (Name = "Simulate Error")]
    SimulateError,

    [Display (Name = "Reset Lockout")]
    Reset,

    [Display (Name = "View Event Logs")]
    ViewLogs,
}
