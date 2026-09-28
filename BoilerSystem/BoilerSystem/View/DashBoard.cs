using BoilerSystem.Models;

namespace BoilerSystem.View;

public class DashBoard
{
    public async Task DisplayDashboard(Boiler boiler)
    {
        while (true)
        {
            RenderConsole.RenderDashboard();
            DisplayView.DisplayMessage("BOILER CONTROLLER SYSTEM");
            DisplayView.DisplayMessage($"Boiler State: {boiler.State}");
            DisplayView.DisplayMessage($"InterLock Switch State: {boiler.Switch}");
            DisplayView.DisplayMessage($"Boiler Sequence: {boiler.Sequence}");

            if (boiler.Sequence == Enums.BoilerSequence.PrePurge || boiler.Sequence == Enums.BoilerSequence.Ignition)
            {
                DisplayView.DisplayMessage($"Remaining Time: {boiler.RemainingTime}");
            }


            RenderConsole.SetCursorBack();
            await Task.Delay(500);
        }
    }
}
