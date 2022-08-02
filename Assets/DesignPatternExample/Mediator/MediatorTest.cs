using UnityEngine;
using System.Collections;
using DesignPattern_Mediator;

public class MediatorTest : MonoBehaviour
{
    void Start()
    {
        UnitTest();
    }

    void UnitTest()
    {
        // 产生中介者
        ConcreteMediator pMediator = new ConcreteMediator();

        // 产生两个Colleague
        ConcreateColleague1 pColleague1 = new ConcreateColleague1(pMediator);
        ConcreateColleague2 pColleague2 = new ConcreateColleague2(pMediator);

        // 设定给中介者
        pMediator.SetColleageu1(pColleague1);
        pMediator.SetColleageu2(pColleague2);

        // 执行
        pColleague1.Action();
        pColleague2.Action();
    }
}
