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


        public static T ReadData<T>(string filePath)
        {
            string jsonRead;
            try
            {
                jsonRead = System.IO.File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(jsonRead);
            }
            catch (FileNotFoundException)
            {
                return default;
            }
        }

        public static void SaveData(Object saveObject, string filePath)
        {
            string json = JsonConvert.SerializeObject(saveObject, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, json);
        }
    }
}
