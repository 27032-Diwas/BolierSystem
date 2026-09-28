using BoilerSystem.Enums;
using BoilerSystem.View;

namespace BoilerSystem.Controller;

/// <summary>
/// Coordinates between view and boiler system controller.
/// </summary>
public class MainMenuController
{
    private readonly BoilerSystemController _controller;

    /// <summary>
    /// Initializes a new instance of the <see cref="BoilerSystemController"/> class.
    /// </summary>
    /// <param name="boilerSystemController"> Instance of boiler system controller. </param>
    public MainMenuController(BoilerSystemController boilerSystemController)
    {
        this._controller = boilerSystemController;
    }

    public void Execute()
    {
        while (true)
        {
            MainMenu option = MenuView.GetMenuOption<MainMenu>(true, "Note: Toggle InterLock -> Reset LockOut -> Start Boiler -> Stop Boiler");

            switch (option)
            {
                case MainMenu.Exit:
                    return;
                case MainMenu.Start:
                    this._controller.StartBoilerSequence(new CancellationTokenSource());
                    break;
                case MainMenu.Stop:
                    this._controller.StopBoilerSequence();
                    break;
                case MainMenu.ToggleInterLock:
                    this._controller.ToggleInterlock();
                    break;
                case MainMenu.SimulateError:
                    this._controller.SimulateError();
                    break;
                case MainMenu.Reset:
                    this._controller.ResetLockOut();
                    break;
                case MainMenu.ViewLogs:
                    this._controller.ViewLogs();
                    break;

            }
        }
    }
}