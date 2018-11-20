using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace _Test
{
    internal class Test8_Dome
    {
        private static PlayerData[] playerDatas;

        private FileHelper jsonFile;
        private FileHelper xmlFile;

        public Test8_Dome ()
        {
            xmlFile = new FileHelper("E:/test/PlayerConifg.xml");
            jsonFile = new FileHelper("E:/test/PlayerConifg.json");
            playerDatas = Test4_Dome.Inst.GetPlayerData;
        }

        /// <summary>
        /// 将 PlayerData[] 写入 "E:/test/PlayerConifg.json";
        /// </summary>
        public void WriteJsonFile ()
        {
            jsonFile.OpenFile(out FileStream fs);

            using (fs)
            {
                var jsonData = JsonConvert.SerializeObject(playerDatas);
                var buffer = Encoding.UTF8.GetBytes(jsonData);

                try
                {
                    fs.Write(buffer, 0, buffer.Length);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// 读取 "E:/test/PlayerConifg.json" 的 数据; 
        /// </summary>
        public PlayerData[] ReadJsonFile ()
        {
            PlayerData[] value = null;

            using (FileStream stream = new FileStream(jsonFile.ToString(), FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                try
                {
                    var buffer = new byte[stream.Length];
                    var count = stream.Read(buffer, 0, buffer.Length);
                    
                    var jsonData = Encoding.UTF8.GetString(buffer);
                    value = JsonConvert.DeserializeObject<PlayerData[]>(jsonData);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                
            }

            return value;
        }

        public void WriteXmlFile()
        {
            xmlFile.OpenFile(out FileStream fs);

            using (fs)
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    var xs = new XmlSerializer(typeof(PlayerData[]));
                    xs.Serialize(sw, playerDatas);
                }
            }
        }

        public PlayerData[] ReadXmlFile()
        {
            PlayerData[] value = null;
            xmlFile.OpenFile(out FileStream fs);

            using (fs)
            {
                using(StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    if (fs.Length < 1) return value;

                    var xs = new XmlSerializer(typeof(PlayerData[]));
                    value = xs.Deserialize(fs) as PlayerData[];
                }
            }

            return value;
        }
    }
}
