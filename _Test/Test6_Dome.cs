using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Test
{
    public class Test6_Dome
    {
        public interface IPlayerManager
        {
            ///登陆
            bool Login(string name, string pwd);

            ///退出
            void Exit();

            ///交友
            void MakingFriends(int playerId);

            ///换装
            void Cosplay(object args);

            /// <summary>
            /// 购买物品
            /// </summary>
            /// <param name="price">物品价格</param>
            /// <returns></returns>
            bool Bay(float price);

            /// <summary>
            /// 战斗
            /// </summary>
            /// <param name="args"></param>
            void Combat(object args);
        }

        public class Player : IPlayerManager
        {
            //金币
            private int Coin;

            private float Power;

            private const bool IsManager = false;

            public bool Bay(float price)
            {
                if (Coin > price)
                    return true;
                return false;
            }

            public void Combat(object args)
            {
                
            }

            public void Cosplay(object args)
            {
                
            }

            public void Exit()
            {
                
            }

            public bool Login(string name, string pwd)
            {
                if(string.IsNullOrEmpty(name) && string.IsNullOrEmpty(pwd))
                {

                }
                return false;
            }

            public void MakingFriends(int playerId)
            {
                
            }
        }

        public class GM : IPlayerManager
        {
            /// <summary>
            /// 金币
            /// </summary>
            private int Coin;

            /// <summary>
            /// 力量
            /// </summary>
            private float Power;

            private bool IsManager;

            void SetCoin(int coin)
            {
                this.Coin = coin;
            }

            void SetPower(int Power)
            {
                this.Power = Power;
            }

            public bool Bay(float price)
            {
                if (Coin > price)
                    return true;
                return false;
            }

            public void Combat(object args)
            {
                //TODO
            }

            public void Cosplay(object args)
            {
                //TODO
            }

            public void Exit()
            {
                //TODO
            }

            public bool Login(string name, string pwd)
            {
                if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(pwd))
                {
                    //TODO
                    
                    IsManager = true;
                }
                return false;
            }

            public void MakingFriends(int playerId)
            {
                //TODO
            }
        }
    }
}
