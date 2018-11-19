using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace _Test
{
    internal class Test8_Dome
    {
        private static PlayerData[] playerDatas;

        private FileHelper fileHelper;

        public Test8_Dome ()
        {
            fileHelper = new FileHelper("E:/test/PlayerConifg.json");
            playerDatas = Test4_Dome.Inst.GetPlayerData;
        }

        public void WriteJsonFile ()
        {
            fileHelper.OpenFile(out FileStream fs);

            using (fs)
            {
                var jsonData = JsonConvert.SerializeObject(playerDatas);
                var buffer = Encoding.UTF8.GetBytes(jsonData);

                fs.Write(buffer, 0, buffer.Length);
            }
        }

        public PlayerData[] ReadJsonFile ()
        {
            PlayerData[] value = null;

            using (FileStream stream = new FileStream(fileHelper.ToString(), FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                var buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);

                var jsonData = Encoding.UTF8.GetString(buffer);
                value = JsonConvert.DeserializeObject<PlayerData[]>(jsonData);
            }

            return value;
        }
    }
}
