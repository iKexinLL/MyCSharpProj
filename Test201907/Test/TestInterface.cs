

using System;

namespace MyTest
{
    public interface ITestWithOut<out TTestWithOut> where TTestWithOut : class, new()
    {
        TTestWithOut Value { get; }
    }

    public interface ITestWithoutOut<TTestWithOut> where TTestWithOut : class, new()
    {
        TTestWithOut Value { get; }
    }

    public class TestInterfaceWithOut : ITestWithOut<AppOptions>
    {
        AppOptions ITestWithOut<AppOptions>.Value => throw new NotImplementedException();

        public static void TestStart(ITestWithOut<AppOptions> iTestWithOut, 
            ITestWithoutOut<AppOptions> iTestWithoutOut)
        {
            AppOptions app = new AppOptions();
            // app.Value.Option = "3";
        }

        
    }

    public class TestInterfaceWithoutOut : ITestWithoutOut<AppOptions>
    {
        AppOptions ITestWithoutOut<AppOptions>.Value => throw new NotImplementedException();

        public static void TestStart(ITestWithOut<AppOptions> iTestWithOut, 
            ITestWithoutOut<AppOptions> iTestWithoutOut)
        {
            
        }
    }

    public class AppOptions
    {
        public string Option {get; set;} = "Option Default Value";

        // public AppOptions Value
        //     => AppOptions;
    }
}