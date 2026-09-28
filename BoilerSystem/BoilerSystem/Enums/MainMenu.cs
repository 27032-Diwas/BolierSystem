using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace BoilerSystem.Enums;

public enum MainMenu
{
    /// <summary>
    /// Represents the option to exit the application.
    /// </summary>
    [Display (Name = "Exit the Application")]
    Exit,

    /// <summary>
    /// Represents the option to start the boiler sequence.
    /// </summary>
    [Display (Name = "Start Boiler Sequence")]
    Start,

    /// <summary>
    /// Represents the option to stop the boiler sequence.
    /// </summary>
    [Display (Name = "Stop Boiler Sequence")]
    Stop,

    /// <summary>
    /// Represents the option to toggle the interlock switch.
    /// </summary>
    [Display (Name = "Toggle Interlock Switch")]
    ToggleInterLock,

    /// <summary>
    /// Represents the option to simulate error.
    /// </summary>
    [Display (Name = "Simulate Error")]
    SimulateError,

    /// <summary>
    /// Represent the option to reset boiler state.
    /// </summary>
    [Display (Name = "Reset Lockout")]
    Reset,

    /// <summary>
    /// Represents the option to view all logs.
    /// </summary>
    [Display (Name = "View Event Logs")]
    ViewLogs,
}