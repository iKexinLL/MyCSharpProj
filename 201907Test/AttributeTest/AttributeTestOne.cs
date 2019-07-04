using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace MyTest.AttributeTest
{
    [AttributeTest("AttributeTestOne", version = 1.0)]
    [AttributeTest("AttributeTestOne", version = 2.0)]
    public class AttributeTestOne
    {
        public static void TestStart()
        {
            var myAttributes = Attribute.GetCustomAttributes(
                            typeof(AttributeTestOne), typeof(AttributeTestAttribute));

            // MySelect(同Select)中,传入的(i,n)是对应的Func<TSource, int, TResult> selector中的TSource, int
            // new {midAttribute = i, Index = n}的作用是将传入的(i, n)加工成字典
            // 也就是说myAttribute的类型是....匿名类型.
            // 原以为是字典的.
            foreach (var myAttribute in myAttributes.MySelect((i, n) => new {midAttribute = i, Index = n}))
            {
                // var mid = (AttributeTestAttribute)myAttribute;
                Console.WriteLine($"myattribute.ClassName is {(myAttribute.midAttribute as AttributeTestAttribute).ClassName}, "
                                + $"myattribute.Version is {(myAttribute.midAttribute as AttributeTestAttribute).Version * myAttribute.Index})");
                SetCursorPos(20 * myAttribute.Index, 20);
            }
            
            MessageBox(0, "Remerber a \"Readkey\" at last line", "My Message Box", 0);
        }

        [DllImport("user32.dll")]
        public static extern int MessageBox(int h, string m, string c, int type);

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);  

    }
    
    public static class TestThisSelect
    {
        public static IEnumerable<TResult> MySelect<TSource, TResult> (this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
            // where TSource: new()
        {
            // 空值判断
            int index = -1;
            foreach (var i in source)
            {
                checked { ++index; }
                yield return selector(i, index);
            }
        }
    }
}