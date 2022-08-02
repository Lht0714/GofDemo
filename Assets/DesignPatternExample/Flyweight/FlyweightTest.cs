using DesignPattern_Flyweight;
using UnityEngine;

public class FlyweightTest : MonoBehaviour
{
    void Start()
    {
        UnitTest();
    }

    void UnitTest()
    {

        // 元件工厂
        FlyweightFactor theFactory = new FlyweightFactor();

        //通过工厂 设置共享元件
        theFactory.GetFlyweight("1", "共用元件1");
        theFactory.GetFlyweight("2", "共用元件2");
        theFactory.GetFlyweight("3", "共用元件3");

        // 取得一个共用元件
        Flyweight theFlyweight = theFactory.GetFlyweight("1", "");
        //输出
        theFlyweight.Operator();

        // 获取不共用的元件
        UnsharedCoincreteFlyweight theUnshared1 = theFactory.GetUnsharedFlyweight("不共用的信息1");
        theUnshared1.Operator();

        // 设定共用元件
        theUnshared1.SetFlyweight(theFlyweight);

        // 获取不共用的元件2，并指定共用元件1
        UnsharedCoincreteFlyweight theUnshared2 = theFactory.GetUnsharedFlyweight("1", "", "不共用的信息2");

        // 同时显示
        Debug.Log("共同显示共享和不共享的内容：：：：：：：：：：：：：");
        theUnshared1.Operator();
        theUnshared2.Operator();

    }
}
