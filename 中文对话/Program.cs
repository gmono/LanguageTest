using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 中文对话
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("月落专用语言思维模拟系统");
            study st = new study();
            //进入询问和回答阶段
            st.Speck += St_Speck;
            for(;;)
            {
                Console.Write("你说：");
                string str = Console.ReadLine();
                st.hear(str);

            }
        }

        private static void St_Speck(string str)
        {
            Console.WriteLine(string.Format("回答：{0}", str));
        }
    }
}
