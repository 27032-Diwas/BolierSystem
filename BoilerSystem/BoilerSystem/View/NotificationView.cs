using BoilerSystem.Service;

namespace BoilerSystem.View;

/// <summary>
/// Contains method to display notification.
/// </summary>
public class NotificationView
{
    private readonly Notification _notification;

    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationView"/> class.
    /// </summary>
    /// <param name="notification"> Instance of notification. </param>
    public NotificationView(Notification notification)
    {
        this._notification = notification;
        this._notification.Notify += this.DisplayNotification;
    }

    /// <summary>
    /// Displays notification in console.
    /// </summary>
    /// <param name="sender"> Instance of sender of notification. </param>
    /// <param name="args"> Instance of notification. </param>
    public void DisplayNotification(object? sender, Notification.NotificationArgs args)
    {
        RenderConsole.ClearNotification();
        RenderConsole.RenderNotification();
        if (args.Event.Equals("ERROR"))
        {
            DisplayView.DisplayMessage($"ERROR: [{args.Message}], System in Lockout");
        }
        else
        {
            DisplayView.DisplayMessage(args.Message);
        }

        RenderConsole.SetCursorBack();
    }
}
