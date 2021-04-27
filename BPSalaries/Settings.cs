using System.Linq;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace BPSalaries
{
    public class Settings
    {
        public int SecondsForPay { get; set; } = 1800;

        public string Announcement { get; set; } = "Next pay day is in {0} seconds.";

        public List<Salary> Salaries { get; set; } = new List<Salary>();

        public void LoadSettings()
        {
            if(!File.Exists(Path.Combine("Plugins", "Salaries", "pays.json")))
            {
                Debug.Log("[Salaries] Settings file not found creating one...");
                SaveSettings();
                return;
            }
            Debug.Log("[Salaries] Loading Settings file ...");
            var json = File.ReadAllText(Path.Combine("Plugins", "Salaries", "pays.json"));
            ParseSettings(JsonConvert.DeserializeObject<Settings>(json));
        }

        //TODO
        public void SaveSettings()
        {
            Debug.LogWarning("[Salaries] Saving settings...");
            var json = JsonConvert.SerializeObject(this,Formatting.Indented);

            if(!File.Exists(Path.Combine("Plugins", "Salaries", "pays.json")))
                Directory.CreateDirectory(Path.Combine("Plugins","Salaries"));

            using(StreamWriter file = File.CreateText(Path.Combine("Plugins","Salaries","pays.json")))
            {
                file.Write(json);
            }
        }

        public int GetPay(string jobName)
        {
            if(!Salaries.Any(x=>x.JobName == jobName)) return 0;
            return Salaries.First(x=>x.JobName == jobName).Pay;
        }

        private void ParseSettings(Settings settings)
        {
            this.Announcement = settings.Announcement;
            this.SecondsForPay = settings.SecondsForPay;
            this.Salaries = settings.Salaries;
        }
    }

    public class Salary
    {
        public string JobName { get; set; }

        public int Pay { get; set; }
    }
}