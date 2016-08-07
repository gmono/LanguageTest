using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 中文对话
{
    /// <summary>
    /// 所有语言对象 的统一类
    /// 元语言对象也就是字只是format为字本身的语言对象
    /// </summary>
    class LObject
    {
        public string Format = "";
        public SortedSet<string> Classes = new SortedSet<string>();
        public SortedSet<string> Contain = new SortedSet<string>();
        public int believe = 0;//确信度
    }
}
