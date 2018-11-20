using System;
using System.Xml;
using System.Collections.Generic;

namespace _Test
{
    [Serializable]
    public class PlayerData
    {
        public int PlayerId;
        public int Level;
        public string PlayerName;
    }

    internal class Test4_Dome
    {
        internal PlayerData[] GetPlayerData => playerDataList.ToArray();

        private static Test4_Dome iset;

        private static List<PlayerData> playerDataList;
        private static Dictionary<int, PlayerData> playerDataDic;

        internal static Test4_Dome Inst => iset;

        static Test4_Dome ()
        {
            iset = new Test4_Dome();
            InitPlayerDataList();
        }

        /// <summary>
        /// 初始化 playerDataList
        /// </summary>
        private static void InitPlayerDataList ()
        {
            playerDataList = new List<PlayerData>();
            playerDataDic = new Dictionary<int, PlayerData>();

            for (int i = 0; i < 10; i++)
            {
                var playerData = new PlayerData
                {
                    PlayerId = 1000 + i,
                    Level = i,
                    PlayerName = $"程序员{i}",
                };

                playerDataList.Add(playerData);
                playerDataDic.Add(playerData.PlayerId, playerData);
            }
        }
    }
}
