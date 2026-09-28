using BoilerSystem.Controller;
using BoilerSystem.Enums;
using BoilerSystem.Models;
using BoilerSystem.Repository;
using BoilerSystem.Service;
using BoilerSystem.View;

namespace BoilerSystem;

/// <summary>
/// Entry point to the application.
/// </summary>
public  class Program
{
    /// <summary>
    /// Starts the application.
    /// </summary>
    public static void Main()
    {
        Notification notification = new ();
        CSVWriter csvWriter = new ("BoilerLog.csv");
        LoggerRepository loggerRepository = new (csvWriter);
        LoggerService loggerService = new (notification, loggerRepository);
        _ = loggerService.LoadLogsAsync();
        Boiler boiler = new (BoilerState.LockOut, InterLockSwitch.Open, BoilerSequence.Idle);
        notification.OnNotify(null, DateTime.UtcNow, "INFO", "Boiler initialized.");
        BoilerService boilerService = new (notification, boiler);
        BoilerSystemController boilerSystemController = new (boilerService, boiler, new CancellationTokenSource(), notification, loggerService);
        MainMenuController mainMenuController = new (boilerSystemController);
        DashBoard dashBoard = new ();
        NotificationView notificationView = new (notification);
        _ = dashBoard.DisplayDashboardAsync(boiler);
        mainMenuController.Execute();
    }
}
