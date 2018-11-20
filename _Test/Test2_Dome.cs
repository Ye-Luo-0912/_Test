using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Test
{
    class Test2_Dome
    {
        //测试字符串
        private string testStr = "YouKia is a Company,China is a Country,I am a Programmer";
        private string[] testStrArr; 

        public Test2_Dome()
        {
            testStrArr = testStr.Split(',');
        }

        /// <summary>
        /// 按 ',' 分割 并输出
        /// </summary>
        public void _Write()
        {
            foreach (var item in testStrArr)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// 把分割的 第一个字符串 转小写并输出
        /// </summary>
        public void WriteToLower()
        {
            var lowerStr = testStrArr.Select(s => s.ToLower());

            foreach (var item in lowerStr)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// 把 第二个字符串 打乱顺序 并按 testStr格式输出
        /// </summary>
        public void WriteAndRandom()
        {
            var sb = new StringBuilder(testStr);
            var len = sb.Length;
            var r = new Random();

            for (int i = 0; i < len; i++)
            {
                var v = r.Next(len);
                var c = sb[i];
                sb[i] = sb[v];
                sb[v] = c;
            }

            sb.Replace(" ", " ,");

            Console.WriteLine(sb);
        }

        /// <summary>
        /// 把 第三个字符串 以5个字符为长度加入换行符 并输出
        /// </summary>
        public void WriteAndInsertLine()
        {
            var sb = new StringBuilder();

            for (int i = 1; i < testStr.Length; i++)
            {
                sb.Append(testStr[i]);

                if(i % 5 == 0)
                {
                    sb.Append("\n");
                }
            }
            
            Console.WriteLine(sb);
        }
    }
}
