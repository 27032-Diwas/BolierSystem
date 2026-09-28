namespace BoilerSystem.View;

/// <summary>
/// Contains methods to render console.
/// </summary>
public static class RenderConsole
{

    private static int _dashboardHeight => Console.WindowHeight / 3;

    private static int _applicationStartRow => _dashboardHeight;

    private static int _applicationStartColumn => 0;

    private static int _notificationStartRow => _dashboardHeight;

    private static int _notificationStartColumn => Console.WindowWidth * 3 / 10;

    private static (int, int) _recentCursorPosition;

    /// <summary>
    /// Renders console for dashboard.
    /// </summary>
    public static void RenderDashboard()
    {
        (_recentCursorPosition.Item1, _recentCursorPosition.Item2) = Console.GetCursorPosition();

        ClearDashboard();

        Console.SetCursorPosition(0, 0);
    }

    /// <summary>
    /// Renders console for application.
    /// </summary>
    public static void RenderApplication()
    {
        (_recentCursorPosition.Item1, _recentCursorPosition.Item2) = Console.GetCursorPosition();

        ClearApplication();

        Console.SetCursorPosition(_applicationStartColumn, _applicationStartRow);
    }

    /// <summary>
    /// Renders console for notification.
    /// </summary>
    public static void RenderNotification()
    {
        (_recentCursorPosition.Item1, _recentCursorPosition.Item2) = Console.GetCursorPosition();

        ClearNotification();

        Console.SetCursorPosition(_notificationStartColumn, _notificationStartRow);
    }

    /// <summary>
    /// Sets cursor back to its original position.
    /// </summary>
    public static void SetCursorBack()
    {
        Console.SetCursorPosition(_recentCursorPosition.Item1, _recentCursorPosition.Item2);
    }

    /// <summary>
    /// Clears application part of console.
    /// </summary>
    public static void ClearApplication()
    {
        int applicationWidth = _notificationStartColumn - _applicationStartColumn;

        for (int row = _applicationStartRow; row < Console.WindowHeight; row++)
        {
            Console.SetCursorPosition(_applicationStartColumn, row);

            Console.Write(new string(' ', applicationWidth));
        }
    }

    /// <summary>
    /// Clears notification part of console.
    /// </summary>
    public static void ClearNotification()
    {
        for (int row = _notificationStartRow; row < Console.WindowHeight; row++)
        {
            Console.SetCursorPosition(_notificationStartColumn, row);

            Console.Write(new string(' ', Console.WindowWidth - _notificationStartColumn));
        }
    }

    /// <summary>
    /// Clears dashboard part of console.
    /// </summary>
    private static void ClearDashboard()
    {
        for (int row = 0; row < _dashboardHeight; row++)
        {
            Console.SetCursorPosition(0, row);

            Console.Write(new string(' ', Console.WindowWidth));
        }
    }
}