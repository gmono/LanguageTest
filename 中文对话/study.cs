using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 中文对话
{
    delegate void SpeckFun(string str);
    /// <summary>
    /// 最初语义网络构建时是不能回答的
    /// </summary>
    [Serializable]
    class study
    {
        Dictionary<string, LObject> objs = new Dictionary<string, LObject>();
        List<LObject> waitobjs = null;//等待回答的序列
        public study()
        {

        }
        public void hear(string str)
        {
            List<LObject> nowobjs = new List<LObject>();
            for(int i=0;i<str.Length;++i)
            {
                string now = str.Substring(i, 1);
                LObject obj = new LObject();
                obj.Format = now;
                obj.believe = int.MaxValue;//单字的确信度都是最高 因为无所谓确信
                if (!objs.ContainsKey(obj.Format))
                {
                    //新的原始表述
                    objs.Add(obj.Format, obj);
                }
                nowobjs.Add(obj);

            }
            analist(nowobjs);
            think();
        }
        private void analist(List<LObject> list)
        {
            //每次进行一次归并
            List<LObject> nowobjs = new List<LObject>();
            int now = 0;//现在处理的位置
            int arrcount = 0;//兼并的obj的数量
            //递归处理函数
            foreach(var obj in list)
            {
                if (now == 0) nowobjs.Add(obj);
                else
                {
                    string nfom = nowobjs[now - 1].Format + nowobjs[now].Format;//生成新的特征串
                    LObject nobj = objs[nfom];
                    if (nobj == null) continue;
                    nowobjs.RemoveAt(now - 1);
                    nobj.believe++;//重复一次加一个确信度
                    nowobjs.Add(nobj);
                    arrcount++;
                }
            }
            if (arrcount != 0) analist(nowobjs);
            else if(nowobjs.Count>1)
            {
                
                //如果还没有归并完成就把整个语句当做一个基本对象放入
                LObject obj = new LObject();
                obj.Format = connectfom(nowobjs);
                obj.believe = 1;//一个新的元对象
                objs.Add(obj.Format,obj);
                //进入学习过程
                studyfun();
            }
        }
        private string connectfom(IEnumerable<LObject> list)
        {
            StringBuilder builder = new StringBuilder();
            foreach(var v in list)
            {
                builder.Append(v.Format);
            }
            return builder.ToString();
        }
        private void think()
        {

        }
        
        private void studyfun(List<LObject> list)
        {
            //学习过程
            //基本学习过程 如果出现次数太多就建立联系
        }
        public event SpeckFun Speck;
    }
}
