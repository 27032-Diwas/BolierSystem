using System.Security.Cryptography.X509Certificates;

namespace BoilerSystem.Service;

public class Notification
{
    public event EventHandler<NotificationArgs>? Notify;
    public class NotificationArgs : EventArgs
    {
        public NotificationArgs(DateTime timeStamp, string Event, string message)
        {
            this.TimeStamp = timeStamp;
            this.Event = Event;
            this.Message = message;
        }

        public DateTime TimeStamp { get; set; }
        public string Event { get; set; }

        public string Message { get; set; }
    }

    public void OnNotify(object? sender, DateTime timeStamp, string Event, string message)
    {
        Notify?.Invoke(sender, new NotificationArgs(timeStamp, Event, message));
    }

}
