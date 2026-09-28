using BoilerSystem.Enums;
using BoilerSystem.Models;

namespace BoilerSystem.Service;

public class BoilerService
{
    private readonly Notification _notification;
    private Boiler _boiler;
    public BoilerService(Notification notification, Boiler boiler)
    {
        this._notification = notification;
        this._boiler = boiler;
    }

    public async Task StartBoilerSystem(CancellationToken token)
    {
        this._boiler.Sequence = BoilerSequence.PrePurge;
        this._boiler.RemainingTime = TimeSpan.FromSeconds(10);
        this._boiler.EndTime = DateTime.UtcNow + TimeSpan.FromSeconds(10);
        this._notification.OnNotify(this, DateTime.UtcNow, "INFO", "Pre Purge sequence started");
        while (this._boiler.RemainingTime > TimeSpan.Zero)
        {
            this._boiler.RemainingTime = this._boiler.EndTime - DateTime.UtcNow;
            await Task.Delay(500, token);
        }


        this._boiler.Sequence = BoilerSequence.Ignition;
        this._boiler.RemainingTime = TimeSpan.FromSeconds(10);
        this._boiler.EndTime = DateTime.UtcNow + TimeSpan.FromSeconds(10);
        this._notification.OnNotify(this, DateTime.UtcNow, "INFO", "Ignition sequence started");
        while (this._boiler.RemainingTime > TimeSpan.Zero)
        {
            this._boiler.RemainingTime = this._boiler.EndTime - DateTime.UtcNow;
            await Task.Delay(500, token);
        }

        this._boiler.Sequence = BoilerSequence.Operational;
        this._notification.OnNotify(this, DateTime.UtcNow, "INFO", "Operational sequence started");
        while (true)
        {
            await Task.Delay(1000, token);
        }
    }
}
