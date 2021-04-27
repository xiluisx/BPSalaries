using BrokeProtocol.Entities;

namespace BPSalaries.Utils
{
    public static class PlayerExtensions
    {
        public static int GetSalary(this ShPlayer player)
        {
            return Core.Instance.Settings.GetPay(player.svPlayer.job.info.shared.jobName);
        }
    }
}