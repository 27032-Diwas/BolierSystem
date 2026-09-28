using BoilerSystem.Enums;

namespace BoilerSystem.View;

public static class DisplayView
{
    public static void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    public static void DisplayLogs(List<string> logs)
    {
        int totalPage = (logs.Count / 5) + 1;
        for (int i = 0; i <= logs.Count - logs.Count % 5;)
        {
            int currentPage = totalPage - (logs.Count - i) / 5;
            RenderConsole.ClearApplication();
            RenderConsole.ClearNotification();
            RenderConsole.RenderApplication();
            Console.WriteLine($"Page {currentPage}/{totalPage}");
            if (currentPage == totalPage)
            {
                for (int j = logs.Count - logs.Count % 5; j < logs.Count; j++)
                {
                    DisplayMessage(logs[j]);
                }
            }
            else
            {
                DisplayMessage($" {logs[i]}\n {logs[i + 1]}\n {logs[i + 2]}\n {logs[i + 3]}\n {logs[i + 4]}");
            }

            Page page = MenuView.GetMenuOption<Page>(false);
            if (page == Page.Exit)
            {
                RenderConsole.ClearNotification();
                return;
            }
            if (page == Page.Previous && i != 0)
            {
                i -= 5;
                continue;
            }
            if (page == Page.Next)
            {
                i += 5;
            }
        }

        RenderConsole.ClearNotification();
        RenderConsole.SetCursorBack();
    }
}
