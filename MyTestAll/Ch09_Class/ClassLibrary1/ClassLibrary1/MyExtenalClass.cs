namespace ClassLibrary1
{
    public class MyExtenalClass
    {
        public const int ConstInt = 12;

        // ReSharper disable once MemberInitializerValueIgnored
        public readonly int ReadonlyInt = 20;

        public MyExtenalClass()
        {
        }

        public MyExtenalClass(int count)
        {
            this.ReadonlyInt = count;
        }

        // ---------------------------
        #region 接口,重写方法测试-->并没有用
        public interface IMyInterface
        {
            void DoSomething();
            void DoSomethingElse();
        }

        public class MyClass : IMyInterface
        {
            public void DoSomething()
            {

            }

            public void DoSomethingElse()
            {

            }
        }
        #endregion

    }
}