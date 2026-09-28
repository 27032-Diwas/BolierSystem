using BoilerSystem.Service;
using ParkingApplication.View;

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
        RenderConsole.RenderNotification();
        DisplayView.DisplayMessage($"{args.TimeStamp}: [{args.Event}] {args.Message}");
    }
}
