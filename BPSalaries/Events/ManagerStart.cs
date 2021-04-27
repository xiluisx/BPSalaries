using System.Collections;
using BrokeProtocol.API;
using BrokeProtocol.Managers;
using UnityEngine;
using BPSalaries.Utils;
using BrokeProtocol.Utility;

namespace BPSalaries.Events
{
    public class ManagerStart : IScript
    {
        [Target(GameSourceEvent.ManagerStart, ExecutionMode.Event)]
        public void OnManagerStart(SvManager manager)
        {
            manager.StartCoroutine(SalaryCoroutine(manager));
        }

        private IEnumerator SalaryCoroutine(SvManager manager)
        {
            Debug.Log("Starting coroutine");
            var time = Core.Instance.Settings.SecondsForPay/3;
            while(true)
            {
                for(int i = 0; i<3; i++)
                {
                    var leftTime = Core.Instance.Settings.SecondsForPay - i*time;
                    Debug.Log(i);
                    ChatHandler.SendToAll(string.Format(Core.Instance.Settings.Announcement, leftTime));
                    yield return new WaitForSeconds(time);
                }
                foreach(var player in manager.connectedPlayers.Values)
                {
                    player.TransferMoney(DeltaInv.AddToMe, player.GetSalary());
		    player.svPlayer.SendGameMessage($"Has ganado ${player.GetSalary()} por trabajar como {player.svPlayer.job.info.shared.jobName}");
                }
		yield return new WaitForSeconds(10f);
            }
        }
    }
}