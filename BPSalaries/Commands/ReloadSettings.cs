using System;
using BrokeProtocol.API;
using BrokeProtocol.Entities;

namespace BPSalaries.Commands
{
    public class ReloadSettings : IScript
    {
        public ReloadSettings()
        {
            CommandHandler.RegisterCommand("reloadsalaries", new Action<ShPlayer>(OnReloadSalaries));
        }

        public void OnReloadSalaries(ShPlayer player)
        {
            player.svPlayer.SendGameMessage("<color=yellow>Reloading Salaries settings...</color>");
            Core.Instance.Settings.LoadSettings();
        }
    }
}