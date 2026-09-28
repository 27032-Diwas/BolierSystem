using BoilerSystem.Enums;
using BoilerSystem.Service;
using BoilerSystem.View;
using System.Reflection.Metadata;

namespace BoilerSystem.Controller;

public class MainMenuController
{
    private readonly BoilerSystemController _controller;
    public MainMenuController(BoilerSystemController boilerSystemController)
    {
        this._controller = boilerSystemController;
    }

    public void Execute()
    {
        while (true)
        {
            MainMenu option = MenuView.GetMenuOption<MainMenu>();

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
                    break;

            }
        }
    }
}
