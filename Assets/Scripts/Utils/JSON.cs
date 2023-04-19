using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Playables;
using Newtonsoft.Json;
using Object = System.Object;

namespace Assets.Scripts.Utils
{
    internal class JSON
    {
        protected JSON() { }


        public static Object ReadData(string fileName)
        {
            string jsonRead;
            try
            {
                jsonRead = System.IO.File.ReadAllText("Data/"+ fileName + ".txt");
                return JsonConvert.DeserializeObject<Object>(jsonRead);
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }

        public static void SaveData(Object saveObject, string fileName)
        {
            string json = JsonConvert.SerializeObject(saveObject);
            System.IO.File.WriteAllText("Data/" + fileName + ".txt", json);
        }
    }
}
