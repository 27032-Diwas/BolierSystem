using BoilerSystem.Constants;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BoilerSystem.View;

/// <summary>
/// Contains operations to display and get menu options.
/// </summary>
public static class MenuView
{
    /// <summary>
    /// Gets menu option from the user.
    /// </summary>
    /// <typeparam name="T"> Type of menu. </typeparam>
    /// <param name="render"> Application render. </param>
    /// <returns> Option selected by user. </returns>
    public static T GetMenuOption<T>(bool render = true)
        where T : struct, Enum
    {
        while (true)
        {
            if (render)
            {
                RenderConsole.RenderApplication();
            }
            DisplayMenu<T>();
            DisplayView.DisplayMessage(PromptMessages.SelectOption);

            string? input = Console.ReadLine();
            if (int.TryParse(input, out int option) && Enum.IsDefined(typeof(T), option))
            {
                if (render)
                {
                    RenderConsole.SetCursorBack();
                }
                return (T)Enum.ToObject(typeof(T), option);
            }
            else
            {
                DisplayView.DisplayMessage("Invalid option. Please try again.");
            }
        }
    }

    /// <summary>
    /// Displays the menu to user.
    /// </summary>
    /// <typeparam name="T"> Type of menu. </typeparam>
    private static void DisplayMenu<T>()
        where T : struct, Enum
    {
        foreach (T option in Enum.GetValues<T>())
        {
            string displayName = GetDisplayName(option);
            DisplayView.DisplayMessage($"{Convert.ToInt32(option)} - {displayName}");
        }
    }

    /// <summary>
    /// Gets display name of the option.
    /// </summary>
    /// <typeparam name="T"> Type of menu. </typeparam>
    /// <param name="option"> Option in the menu. </param>
    /// <returns> Display name of the option. </returns>
    private static string GetDisplayName<T>(T option) where T : struct, Enum
    {
        MemberInfo memberInfo = typeof(T).GetMember(option.ToString())[0];
        if (memberInfo is not null)
        {
            DisplayAttribute? displayNameAttribute = memberInfo.GetCustomAttribute<DisplayAttribute>();
            if (displayNameAttribute is not null)
            {
                return displayNameAttribute.Name ?? option.ToString();
            }
        }

        return option.ToString();
    }
}
