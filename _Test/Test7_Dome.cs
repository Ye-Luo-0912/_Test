using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace _Test
{
    internal class Test7_Dome
    {
        private static PlayerData[] playerDatas;

        private FileHelper fileHelper;
        private BinaryFormatter bf;

        public Test7_Dome ()
        {
            bf = new BinaryFormatter();
            fileHelper = new FileHelper("E:/test/PlayerConifg.dat");

            playerDatas = Test4_Dome.Inst.GetPlayerData;
        }

        public void WriteFile ()
        {
            fileHelper.OpenFile(out FileStream fs);

            using (fs)
            {
                using (BinaryWriter bw = new BinaryWriter(fs,Encoding.UTF8))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bf.Serialize(ms, playerDatas);
                        bw.Write(ms.ToArray());
                    }
                }
                
            }
        }

        public PlayerData[] ReadFile ()
        {
            fileHelper.OpenFile(out FileStream fs);
            PlayerData[] value = null;

            using (fs)
            {
                try
                {
                    using (BinaryReader br = new BinaryReader(fs, Encoding.UTF8))
                    {
                        var buffer = new byte[fs.Length];
                        br.Read(buffer, 0, buffer.Length);
                        using (MemoryStream ms = new MemoryStream(buffer))
                        {
                            value = bf.Deserialize(ms) as PlayerData[];
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }

            return value;
        }
    }
}
