using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAll
{
    class FuncDemo
    {

        public static void FuncDemoTest()
        {
            Func<InputArgs, Result> func = TsetFunction;
            Console.WriteLine("第一种方式：");
            Console.WriteLine(func(new InputArgs("zhangqs008", "123456")));

            Console.WriteLine("=============================================");

            Console.WriteLine("第二种方式：");
            CallMethod(func, new InputArgs("zhangqs008", "1234567")); //或者   
            CallMethod(TsetFunction, new InputArgs("zhangqs008", "1234567"));
        }
        
        public static Result TsetFunction(InputArgs input)
        {
            Result result = new Result
            {
                Flag = String.Compare("zhangqs008", input.UserName, StringComparison.OrdinalIgnoreCase) == 0 &
                       String.Compare("123456", input.Password, StringComparison.OrdinalIgnoreCase) == 0,
                Msg = "当前调用者：" + input.UserName
            };
            return result;
        }

        public static void CallMethod<T>(Func<T, Result> func, T item)
        {
            Result result = func(item);
            Console.WriteLine(result.ToString());
        }
        
        /// <summary>  
        /// 方法参数  
        /// </summary>  
        public class InputArgs
        {
            public InputArgs(string userName, string password)
            {
                UserName = userName;
                Password = password;
            }

            public string UserName { get; set; }
            public string Password { get; set; }
        }

        /// <summary>  
        /// 方法结果  
        /// </summary>  
        public class Result
        {
            public string Msg { get; set; }
            public bool Flag { get; set; }
            public override string ToString()
            {
                return $"Flag:{Flag},Msg:{Msg}";
            }
        }
    }

}
