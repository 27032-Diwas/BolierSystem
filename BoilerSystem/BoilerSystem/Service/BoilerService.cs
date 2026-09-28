using BoilerSystem.Constants;
using BoilerSystem.Enums;
using BoilerSystem.Models;

namespace BoilerSystem.Service;

/// <summary>
/// Contains all boiler related operations.
/// </summary>
public class BoilerService
{
    private readonly Notification _notification;
    private readonly Boiler _boiler;

    /// <summary>
    /// Initializes a new instance of the <see cref="BoilerService"/> class.
    /// </summary>
    /// <param name="notification"> Instance of notification. </param>
    /// <param name="boiler"> Instance of boiler. </param>
    public BoilerService(Notification notification, Boiler boiler)
    {
        this._notification = notification;
        this._boiler = boiler;
    }

    /// <summary>
    /// Starts the boiler system.
    /// </summary>
    /// <param name="token"></param>
    /// <returns> Task. </returns>
    public async Task StartBoilerSystemAsync(CancellationToken token)
    {
        this._boiler.Sequence = BoilerSequence.PrePurge;
        this._boiler.RemainingTime = TimeSpan.FromSeconds(10);
        this._boiler.EndTime = DateTime.UtcNow + TimeSpan.FromSeconds(10);
        while (this._boiler.RemainingTime > TimeSpan.Zero)
        {
            this._boiler.RemainingTime = this._boiler.EndTime - DateTime.UtcNow;
            await Task.Delay(500, token);
        }
        this._notification.OnNotify(this, DateTime.UtcNow, HeaderMessages.Info, InfoMessages.Phase1Complete);


        this._boiler.Sequence = BoilerSequence.Ignition;
        this._boiler.RemainingTime = TimeSpan.FromSeconds(10);
        this._boiler.EndTime = DateTime.UtcNow + TimeSpan.FromSeconds(10);
        while (this._boiler.RemainingTime > TimeSpan.Zero)
        {
            this._boiler.RemainingTime = this._boiler.EndTime - DateTime.UtcNow;
            await Task.Delay(500, token);
        }
        this._notification.OnNotify(this, DateTime.UtcNow, HeaderMessages.Info, InfoMessages.Phase2Complete);

        this._boiler.Sequence = BoilerSequence.Operational;
        this._notification.OnNotify(this, DateTime.UtcNow, HeaderMessages.Info, InfoMessages.BoilerOperational);
        while (true)
        {
            await Task.Delay(1000, token);
        }
    }
}
