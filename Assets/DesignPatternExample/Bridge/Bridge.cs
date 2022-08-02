using UnityEngine;
using System.Collections;

namespace DesignPattern_Bridge
{
    // 定义类别之间共用界面
    public abstract class Implementor
    {
        public abstract void OperationImp();
    }

    // 實作Implementor所訂之介面
    public class ConcreteImplementor1 : Implementor//手枪
    {
        public ConcreteImplementor1() { }

        public override void OperationImp()
        {
            Debug.Log("执行Concrete1   Implementor.OperationImp");
        }
    }

    // 實作Implementor所訂之介面
    public class ConcreteImplementor2 : Implementor//霰弹枪
    {
        public ConcreteImplementor2() { }

        public override void OperationImp()
        {
            Debug.Log("执行Concrete2    Implementor.OperationImp");
        }
    }




    // 抽象體的介面,維護指向Implementor的物件 reference
    public abstract class Abstraction
    {
        private Implementor m_Imp = null;

        public void SetImplementor(Implementor Imp)
        {
            m_Imp = Imp;
        }

        public virtual void Operation()
        {
            if (m_Imp != null)
                m_Imp.OperationImp();
        }
    }

    // 擴充Abstraction所訂之介面
    public class RefinedAbstraction1 : Abstraction//士兵1
    {
        public RefinedAbstraction1() { }

        public override void Operation()
        {
            Debug.Log("物件   RefinedAbstraction1");
            base.Operation();
        }
    }

    // 擴充Abstraction所訂之介面
    public class RefinedAbstraction2 : Abstraction//怪物
    {
        public RefinedAbstraction2() { }

        public override void Operation()
        {
            Debug.Log("物件   RefinedAbstraction2");
            base.Operation();
        }
    }

}
