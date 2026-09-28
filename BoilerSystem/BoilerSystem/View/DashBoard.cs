using BoilerSystem.Models;

namespace BoilerSystem.View;

/// <summary>
/// Contains display dashboard method.
/// </summary>
public class DashBoard
{
    /// <summary>
    /// Displays information in dashboard.
    /// </summary>
    /// <param name="boiler"> Instance of boiler. </param>
    /// <returns> Task. </returns>
    public async Task DisplayDashboardAsync(Boiler boiler)
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
