using Terminal.Gui;

namespace WeatherMonitor.Extensions
{
    public static class WindowExtensions
    {
        public static void LoadWindow(this Window current, Window window, Action callback)
        {
            Application.Top.Remove(current);
            Application.Top.Add(window);
            callback?.Invoke();
            Application.Refresh();
        }
    }
}
