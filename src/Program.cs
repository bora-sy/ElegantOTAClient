namespace ElegantOTAClient
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            ApplicationConfiguration.Initialize();
            Application.Run(new FormConfig());
        }
    }
}