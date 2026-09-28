using BoilerSystem.Service;

namespace BoilerSystem.View;

public class NotificationView
{
    private readonly Notification _notification;
    public NotificationView(Notification notification)
    {
        this._notification = notification;
        this._notification.Notify += this.DisplayNotification;
    }

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
