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
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    bf.Serialize(sw.BaseStream, playerDatas);
                }

                //using (MemoryStream ms = new MemoryStream())
                //{
                //    
                //    using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                //    {
                //        var buffer =  ms.ToArray();
                //        sw.BaseStream.Write(buffer, 0, buffer.Length);
                //    }
                //}
            }
        }

        public PlayerData[] ReadFile ()
        {
            fileHelper.OpenFile(out FileStream fs);
            PlayerData[] value = null;

            using (fs)
            {
                using (BinaryReader br = new BinaryReader(fs, Encoding.UTF8))
                {
                    try
                    {
                        value = bf.Deserialize(fs) as PlayerData[];
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                }
            }

            return value;
        }
    }
}
