using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Test
{
    public class Test5_Dome
    {
        /// <summary>
        /// 事件执行 时 传入的 参数
        /// </summary>
        public class EnentArgs
        {
            int id;
        }

        public Test5_Dome()
        {

        }

        /// <summary>
        /// OnClick 委托 用于执行OnClick事件
        /// </summary>
        private static Action<object, EnentArgs> OnClick;

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="action"></param>
        public static void AddOnClickEvent(Action<object, EnentArgs> action)
        {
            OnClick += action;
        }


        /// <summary>
        /// 移除事件
        /// </summary>
        /// <param name="action"></param>
        public static void RemoveOnClickEvent(Action<object, EnentArgs> action)
        {
            OnClick -= action;
        }

        /// <summary>
        /// 执行事件 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="args"></param>
        private void Run(object obj, EnentArgs args)
        {
            if (OnClick != null)
                OnClick.Invoke(obj, args);
        }
    }
}
