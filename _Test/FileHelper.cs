using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Test
{
    internal class FileHelper
    {
        public FileHelper (string path)
        {
            file = new FileInfo($@"{path}");
        }

        private FileInfo file;

        public void OpenFile (out FileStream stream)
        {
            if (!this.file.Exists)
            {
                var dir = file.Directory;

                if (!dir.Exists)
                    dir.Create();
            }

            stream = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        /// <summary>
        /// 以字符串形式 返回 文件 路径
        /// </summary>
        /// <returns></returns>
        public override string ToString ()
        {
            return file.ToString();
        }
    }
}
