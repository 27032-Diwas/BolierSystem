using System.Security.Cryptography.X509Certificates;

namespace BoilerSystem.Service;

/// <summary>
/// Contains all notification related operations.
/// </summary>
public class Notification
{
    public event EventHandler<NotificationArgs>? Notify;

    /// <summary>
    /// Notification event args.
    /// </summary>
    public class NotificationArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationArgs"/> class.
        /// </summary>
        /// <param name="timeStamp"> Date time of notification. </param>
        /// <param name="Event"> Notification event. </param>
        /// <param name="message"> Notification message. </param>
        public NotificationArgs(DateTime timeStamp, string Event, string message)
        {
            this.TimeStamp = timeStamp;
            this.Event = Event;
            this.Message = message;
        }

        /// <summary>
        /// Gets or set time stamp.
        /// </summary>
        /// <value> Time stamp of event. </value>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets event.
        /// </summary>
        /// <value> Event of notification. </value>
        public string Event { get; set; }

        /// <summary>
        /// Gets or sets notification message.
        /// </summary>
        /// <value> Notification message. </value>
        public string Message { get; set; }
    }

    /// <summary>
    /// Invoke the notification event.
    /// </summary>
    /// <param name="sender"> Instance of sender. </param>
    /// <param name="timeStamp"> Time stamp of notification. </param>
    /// <param name="Event"> Event of notification. </param>
    /// <param name="message"> Message of notification. </param>
    public void OnNotify(object? sender, DateTime timeStamp, string Event, string message)
    {
        Notify?.Invoke(sender, new NotificationArgs(timeStamp, Event, message));
    }

}
