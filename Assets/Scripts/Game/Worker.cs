using Assets.Scripts.Utils;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    public class Worker : IPredictEvent
    {
        private int type;
        private float cooldown; //minutes
        private DateTime previousWorkTime;

        [Index(0)]
        public int Type { get => type; set => type = value; }
        [Index(1)]
        public float Cooldown { get => cooldown; set => cooldown = value; }
        [Index(2)]
        public DateTime PreviousWorkTime { get => previousWorkTime; set => previousWorkTime = value; }
       
               
        public Worker() {
            previousWorkTime = DateTime.Now;
        }

        public Worker(int type)
        {
            List<Worker> workerDataSheet = ReadConfigFile();
            if (workerDataSheet == null)
            {
                WriteConfigFile();
                workerDataSheet = ReadConfigFile();
            }
            else
            {
                foreach(Worker worker in workerDataSheet)
                {
                    if (worker.type == type)
                    {
                        this.type = type;
                        this.cooldown = worker.cooldown;
                        break;
                    }
                }
            }
            previousWorkTime = DateTime.Now;
        }
        public Worker(int type, float cooldown)
        {
            this.type = type;
            this.cooldown = cooldown;
        }

        public string Work()
        {
            TimeSpan timeCoolDown = TimeSpan.FromMinutes(cooldown);
            TimeSpan denta = DateTime.Now - previousWorkTime;
            if (denta >= timeCoolDown)
            {
                previousWorkTime += timeCoolDown;
                int work = new Random().Next(1, 3);
                switch (work)
                {
                    case 1:
                        return "Havert";
                    case 2:
                        return "Plant";
                }
                
            }
            return null;
        }

        public string Work(DateTime time)
        {
            if (time > previousWorkTime)
            {
                TimeSpan timeCoolDown = TimeSpan.FromMinutes(cooldown);
                TimeSpan denta = time - previousWorkTime;
                if (denta >= timeCoolDown)
                {
                    previousWorkTime += timeCoolDown;
                    int work = new Random().Next(1, 3);
                    switch (work)
                    {
                        case 1:
                            return "Havert";
                        case 2:
                            return "Plant";
                    }

                }
            }
            
            return null;
        }

        public List<DateTime> GetPredictEvent(DateTime time)
        {
            List<DateTime> result = new List<DateTime>();
            for (DateTime t = previousWorkTime; t < time; t += TimeSpan.FromMinutes(cooldown))
            {
                result.Add(t);
            }
            return result;
        }
        public static void WriteConfigFile()
        {
            List<Worker> defaultWorker = new List<Worker>();
            defaultWorker.Add(new(1, 2));

            CSV.WriteFile("Config/Worker.csv", defaultWorker);
        }

        public static List<Worker> ReadConfigFile()
        {
            return CSV.ReadFile<Worker>("Config/Worker.csv");
        }

        public override string ToString()
        {
            return $"{{{nameof(Type)}={Type.ToString()}, {nameof(Cooldown)}={Cooldown.ToString()}, {nameof(PreviousWorkTime)}={PreviousWorkTime.ToString()}}}";
        }

        
    }
}
