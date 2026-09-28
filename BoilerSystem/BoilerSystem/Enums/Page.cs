using System.ComponentModel.DataAnnotations;

namespace BoilerSystem.Enums;

public enum Page
{
    [Display (Name = "Exit the process")]
    Exit,

    [Display (Name = "Previous")]
    Previous = 1,

    [Display (Name = "Next")]
    Next = 2
}
