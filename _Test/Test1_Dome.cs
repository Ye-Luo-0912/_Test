using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Test
{

    /// <summary>
    /// 测试题1
    /// </summary>
    public class Test1_Dome
    {
        /// <summary>
        /// 玩家状态
        /// </summary>
        public enum PlayerState
        {
            /// <summary>
            /// 行走
            /// </summary>
            Walk,
            /// <summary>
            /// 战斗
            /// </summary>
            Combat,
            /// <summary>
            /// 等待
            /// </summary>
            Wait,
        }

        public class Plyaer
        {
            //玩家 移动速度
            float speed = 0;

            public PlayerState State;


            /// <summary>
            /// 获取 玩家状态
            /// </summary>
            /// <param name="state">状态所对应的常量值</param>
            /// <returns></returns>
            public PlayerState GetPlayerState(int state)
            {
                //返回state 代表的状态 如果值没定义这抛出异常
                if (Enum.IsDefined(typeof(PlayerState), state))
                {
                    return (PlayerState)state;
                }

                throw new NotImplementedException($"{state}不再范围");
            }

            /// <summary>
            /// 获取 玩家状态
            /// </summary>
            /// <param name="state">状态所对应的常量值</param>
            /// <returns></returns>
            public PlayerState GetPlayerState(string value)
            {
                if (Enum.TryParse(value, out PlayerState state))
                {
                    return state;
                }

                throw new NotImplementedException($"{value}不存在");
            }

            private void Combat(object args)
            {
                ///
            }

            private void Wait()
            {
                ///
            }

            /// <summary>
            /// 设置 玩家 状态下的行为
            /// </summary>
            /// <param name="state"></param>
            private void SetPlayer(PlayerState state)
            {
                switch (state)
                {
                    case PlayerState.Walk:
                        {
                            speed = 3;
                        }
                        break;
                    case PlayerState.Combat:
                        {
                            Combat(null);
                        }
                        break;
                    case PlayerState.Wait:
                        {
                            Wait();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        
    }

    
}
