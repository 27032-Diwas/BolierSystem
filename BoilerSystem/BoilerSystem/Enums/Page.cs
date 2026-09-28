using System.ComponentModel.DataAnnotations;

namespace BoilerSystem.Enums;

public enum Page
{
    /// <summary>
    /// Represents the option to exit the process.
    /// </summary>
    [Display (Name = "Exit the process")]
    Exit,

    /// <summary>
    /// Represents the option to navigate to previous page.
    /// </summary>
    [Display (Name = "Previous")]
    Previous = 1,

    /// <summary>
    /// Represents the option to navigate to next page.
    /// </summary>
    [Display (Name = "Next")]
    Next = 2
}
