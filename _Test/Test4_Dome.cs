using System;
using System.Xml;
using System.Collections.Generic;
using System.Web.Razor.Parser.SyntaxTree;

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

        private static readonly Test4_Dome iset;

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
        

        private void RemoveItem(Func<PlayerData, bool> func)
        {
            Span<PlayerData> datas = playerDataList.ToArray();
            if (datas.IsEmpty) return;

            List<int> rList = new List<int>();
            for (int i = 1; i < datas.Length; i++)
            {
                if (func(playerDataList[i]))
                {
                    rList.Add(i);
                }
            }

            Span<int> li = rList.ToArray();
            for (int i = 0; i < li.Length; i++)
            {
                playerDataList.RemoveAt(li[i]);
            }
        }

        public void RemoveDicItem(Func<PlayerData, bool> func)
        {
            var list = new List<int>();
            int[] ks = null;

            playerDataDic.Keys.CopyTo(ks, 0);
            Span<int> keys = ks;

            for (int i = 0; i < keys.Length; i++)
            {
                if (func(playerDataDic[keys[i]]))
                {
                    playerDataDic.Remove(keys[i]);
                }
            }
        }


        class compares : IComparer<PlayerData>
        {
            public int Compare(PlayerData x, PlayerData y)
            {
                if (x.Level < y.Level)
                    return 0;
                else if(x.Level > y.Level)
                    return -1;
                else
                {
                    if (x.PlayerId > y.PlayerId)
                        return 1;
                    else
                        return 0;
                }
            }
        }

        /// <summary>
        /// 对 playerData排序
        /// </summary>
        public void SortPlayerData()
        {
            compares comp = new compares();

            playerDataList.Sort(comp);
        }

        /// <summary>
        /// 删除对应条件数据
        /// </summary>
        public void RemovePlayerData()
        {
            //删除 Level < 2 的数据 和 dic 的数据
            RemoveItem(item => item.Level <= 3);
        }
    }
}
