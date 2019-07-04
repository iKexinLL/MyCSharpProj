using System;
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

            foreach (var myAttribute in myAttributes)
            {
                // var mid = (AttributeTestAttribute)myAttribute;
                Console.WriteLine($"myattribute.ClassName is {(myAttribute as AttributeTestAttribute).ClassName}, "
                                + $"myattribute.Version is {(myAttribute as AttributeTestAttribute).Version})");
                SetCursorPos(20, 20);
            }
            
            MessageBox(0, "TestMessage", "My Message Box", 0);
        }

        [DllImport("user32.dll")]
        public static extern int MessageBox(int h, string m, string c, int type);

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);  
    }
}