using BoilerSystem.Controller;
using BoilerSystem.Enums;
using BoilerSystem.Models;
using BoilerSystem.Service;
using BoilerSystem.View;

namespace BoilerSystem;

public  class Program
{
    public static void Main()
    {
        Notification notification = new Notification();
        LoggerService loggerService = new LoggerService();
        Boiler boiler = new Boiler(BoilerState.LockOut, InterLockSwitch.Open, BoilerSequence.Idle);
        notification.OnNotify(null, DateTime.UtcNow, "INFO", "Boiler initialized.");
        BoilerService boilerService = new BoilerService(notification, boiler);
        BoilerSystemController boilerSystemController = new BoilerSystemController(boilerService, boiler, new CancellationTokenSource(), notification);
        MainMenuController mainMenuController = new MainMenuController(boilerSystemController);
        DashBoard dashBoard = new DashBoard();
        NotificationView notificationView = new NotificationView(notification);
        _ = dashBoard.DisplayDashboard(boiler);
        mainMenuController.Execute();
    }
}
