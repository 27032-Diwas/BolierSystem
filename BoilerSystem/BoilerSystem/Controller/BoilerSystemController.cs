using BoilerSystem.Enums;
using BoilerSystem.Models;
using BoilerSystem.Service;
using BoilerSystem.View;

namespace BoilerSystem.Controller;

public class BoilerSystemController
{
    private readonly BoilerService _boilerService;
    private readonly Boiler _boiler;
    private readonly Notification _notifications;
    private readonly LoggerService _loggerService;
    private CancellationTokenSource _cancellationTokenSource;

    /// <summary>
    /// Initializes a new instance of the <see cref="BoilerSystemController"/> class.
    /// </summary>
    /// <param name="boilerService"> Instance of boiler service. </param>
    /// <param name="boiler"> Instance of boiler</param>
    /// <param name="cancellationTokenSource"> Instance of cancellation token source. </param>
    /// <param name="notifications"> Instance of notification. </param>
    /// <param name="loggerService"> Instance of logger service. </param>
    public BoilerSystemController(BoilerService boilerService, Boiler boiler, CancellationTokenSource cancellationTokenSource, Notification notifications, LoggerService loggerService)
    {
        this._boilerService = boilerService;
        this._boiler = boiler;
        this._cancellationTokenSource = cancellationTokenSource;
        this._notifications = notifications;
        this._loggerService = loggerService;
    }

    /// <summary>
    /// Starts the boiler sequence.
    /// </summary>
    /// <param name="cancellationTokenSource"> Instance of cancellation token source. </param>
    public void StartBoilerSequence(CancellationTokenSource cancellationTokenSource)
    {
        try
        {
            if (this._boiler.Switch == InterLockSwitch.Open)
            {
                this._notifications.OnNotify(this, DateTime.UtcNow, "WARNING", "Toggle the interlock switch to close state to start boiler sequence.");
                return;
            }
            else if (this._boiler.State == BoilerState.LockOut)
            {
                this._notifications.OnNotify(this, DateTime.UtcNow, "WARNING", "Reset the lock out to start boiler sequence.");
                return;
            }

            this._cancellationTokenSource = cancellationTokenSource;
            _ = this._boilerService.StartBoilerSystemAsync(this._cancellationTokenSource.Token);
            this._notifications.OnNotify(this, DateTime.UtcNow, "INFO", "Boiler sequence started.");
        }
        catch (OperationCanceledException)
        {
            this._notifications.OnNotify(this, DateTime.UtcNow, "INFO", "Boiler sequence cancelled successfully.");
        }
    }

    /// <summary>
    /// Stops the boiler sequence.
    /// </summary>
    public void StopBoilerSequence()
    {
        if (this._boiler.Sequence == BoilerSequence.Idle)
        {
            this._notifications.OnNotify(this, DateTime.UtcNow, "WARNING", "No active boiler sequence to stop.");
            return;
        }

        this._notifications.OnNotify(this, DateTime.UtcNow, "INFO", "Boiler sequence cancelled.");
        this._boiler.Sequence = BoilerSequence.Idle;
        this._cancellationTokenSource.Cancel();
    }

    /// <summary>
    /// Resets the boiler system state.
    /// </summary>
    public void ResetLockOut()
    {
        if (this._boiler.Sequence != BoilerSequence.Idle)
        {
            StopBoilerSequence();
            this._boiler.Sequence = BoilerSequence.Idle;
            this._boiler.State = BoilerState.LockOut;
            this._notifications.OnNotify(this, DateTime.UtcNow, "INFO", "Boiler state changed to lockout.");
            return;
        }

        if (this._boiler.State == BoilerState.LockOut && this._boiler.Switch == InterLockSwitch.Close)
        {
            this._boiler.State = BoilerState.Ready;
            this._notifications.OnNotify(this, DateTime.UtcNow, "INFO", "Boiler state changed to ready.");
        }
    }

    /// <summary>
    /// Toggle the interlock switch.
    /// </summary>
    public void ToggleInterlock()
    {
        if (this._boiler.Switch == InterLockSwitch.Open)
        {
            this._boiler.Switch = InterLockSwitch.Close;
            this._notifications.OnNotify(this, DateTime.UtcNow, "INFO", "InterLock switch toggled to close.");
            return;
        }

        this._boiler.Switch = InterLockSwitch.Open;
        this._notifications.OnNotify(this, DateTime.UtcNow, "INFO", "InterLock switch toggled to open.");
    }

    /// <summary>
    /// Simulates error.
    /// </summary>
    public void SimulateError()
    {
        if (this._boiler.Sequence != BoilerSequence.Operational)
        {
            this._notifications.OnNotify(this, DateTime.UtcNow, "WARNING", "Can only simulate error when boiler sequence is operational.");
            return;
        }

        StopBoilerSequence();
        this._boiler.Sequence = BoilerSequence.Idle;
        this._boiler.State = BoilerState.LockOut;
        this._boiler.Switch = InterLockSwitch.Open;
        this._notifications.OnNotify(this, DateTime.UtcNow, "Error", "Simulated Error.");
        return;
    }

    /// <summary>
    /// Displays all logs.
    /// </summary>
    public void ViewLogs()
    {
        DisplayView.DisplayLogs(this._loggerService.GetAllLogs());
    }
}
