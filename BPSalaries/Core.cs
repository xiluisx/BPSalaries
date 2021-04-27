using BrokeProtocol.API;

namespace BPSalaries
{
    public class Core : Plugin
    {
        public static Core Instance { get; set; }

        public Settings Settings { get; set; } = new Settings();

        public Core()
        {
            Instance = this;
            Info = new PluginInfo("BPSalaries", "bps");
            Settings.LoadSettings();
        }
    }
}
