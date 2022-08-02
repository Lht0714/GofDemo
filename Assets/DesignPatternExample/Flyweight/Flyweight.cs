using UnityEngine;
using System.Collections.Generic;
namespace DesignPattern_Flyweight
{
    /// <summary>
    /// 可以被共用的Flyweight介面	
    /// </summary>
    public abstract class Flyweight
    {
        //共用数据
        protected string m_Content; //顯示的內容
        public Flyweight() { }
        public Flyweight(string Content)
        {
            m_Content = Content;
        }
        public string GetContent()
        {
            return m_Content;
        }
        public abstract void Operator();
    }

    /// <summary>
    /// 共享元件
    /// </summary>
    public class ConcreteFlyweight : Flyweight
    {
        public ConcreteFlyweight(string Content) : base(Content)
        {
        }

        public override void Operator()
        {
            Debug.Log("共享元件的内容[" + m_Content + "]");
        }
    }

    /// <summary>
    /// // 不共享的元件  不必须继承
    /// </summary>
    public class UnsharedCoincreteFlyweight  //: Flyweight
    {
        //不共享持有共享
        Flyweight m_Flyweight = null; // 共享的元件
        string m_UnsharedContent;     // 不共享的元件

        public UnsharedCoincreteFlyweight(string Content)
        {
            m_UnsharedContent = Content;
        }

        // 设置共享的元件
        public void SetFlyweight(Flyweight theFlyweight)
        {
            m_Flyweight = theFlyweight;
        }

        public void Operator()
        {
            string Msg = string.Format("不共享的元件内容：[{0}]", m_UnsharedContent);
            if (m_Flyweight != null)
                Msg += "包含了：" + m_Flyweight.GetContent();
            Debug.Log(Msg);
        }
    }

    /// <summary>
    /// 负责生成Flyweight的工厂界面
    /// </summary>
    public class FlyweightFactor
    {
        Dictionary<string, Flyweight> m_FlyweightsDic = new Dictionary<string, Flyweight>();

        // 获取共用的元件 
        public Flyweight GetFlyweight(string Key, string Content)
        {
            if (m_FlyweightsDic.ContainsKey(Key))
                return m_FlyweightsDic[Key];

            // 生成并设置内容
            ConcreteFlyweight theFlyweight = new ConcreteFlyweight(Content);
            m_FlyweightsDic[Key] = theFlyweight;
            Debug.Log("新的共享元件：Key[" + Key + "] Content[" + Content + "]");
            return theFlyweight;
        }

        // 赋值不公有的元件(只取得不共用的Flyweight)
        public UnsharedCoincreteFlyweight GetUnsharedFlyweight(string Content)
        {
            return new UnsharedCoincreteFlyweight(Content);
        }

        // 取得元件(包含共用部份的Flyweight)
        public UnsharedCoincreteFlyweight GetUnsharedFlyweight(string Key, string SharedContent, string UnsharedContent)
        {
            // 先取得共用的部份
            Flyweight SharedFlyweight = GetFlyweight(Key, SharedContent);

            // 生成元件
            UnsharedCoincreteFlyweight theFlyweight = new UnsharedCoincreteFlyweight(UnsharedContent);
            theFlyweight.SetFlyweight(SharedFlyweight); // 设置共享的部份
            return theFlyweight;
        }
    }
}