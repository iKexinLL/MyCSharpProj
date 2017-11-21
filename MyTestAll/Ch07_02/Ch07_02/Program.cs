using System;
using static System.Console;

namespace Ch07_02
{
    /* 这个主要需要理解异常的执行顺序
     * 当执行到nested index时,再次执行了ThrowException("index");
     * 那么,第84行当throw;就是一个关键
     * 如果没有throw语句,那么Main()中的try..catch无法捕捉到方法内的异常
     * 因为这个异常被nested index中的try..catch处理了
     * 然后throw的话,也会先执行nested index中的finally
     * 然后交给Main()中的catch来捕获异常
     * 注意throw出来的异常类型
     */

    class Program
    {
        static string[] eTypes =
        {
            "none", "simple", "index",
            "nested index", "filter"
        };

        static void Main(string[] args)
        {
            foreach (string eType in eTypes)
            {
                try
                {
                    WriteLine("Main() try block reached."); // Line 21
                    WriteLine($"ThrowException(\"{eType}\") called.");
                    ThrowException(eType);
                    WriteLine("Main() try block continues."); // Line 24
                }
                catch (System.IndexOutOfRangeException e) when (eType == "filter") // Line 26
                {
                    BackgroundColor = ConsoleColor.Red;
                    WriteLine(
                        $"Main() FILTERED System.IndexOutOfRangeException catch block reached. Message:\n\"{e.Message}\"");
                    ResetColor();
                }
                catch (System.IndexOutOfRangeException e) // Line 32
                {
                    WriteLine($"Main() System.IndexOutOfRangeException catch block reached. Message:\n\"{e.Message}\"");
                }
                catch // Line 36
                {
                    WriteLine("Main() general catch block reached.");
                }
                finally
                {
                    WriteLine("Main() finally block reached.");
                }
                WriteLine();
            }
            ReadKey();
        }

        static void ThrowException(string exceptionType)
        {
            WriteLine($"ThrowException(\"{exceptionType}\") reached.");

            switch (exceptionType)
            {
                case "none":
                    WriteLine("Not throwing an exception.");
                    break; // Line 57
                case "simple":
                    WriteLine("Throwing System.Exception.");
                    throw new System.Exception(); // Line 60
                case "index":
                    WriteLine("Throwing System.IndexOutOfRangeException.");
                    eTypes[5] = "error"; // Line 63
                    break;
                case "nested index":
                    try // Line 66
                    {
                        WriteLine("ThrowException(\"nested index\") " +
                                  "try block reached.");
                        WriteLine("ThrowException(\"index\") called.");
                        ThrowException("index"); // Line 71
                    }
                    catch (System.Exception e) // Line 66
                    {
                        WriteLine("ThrowException(\"nested index\") general"
                                  + " catch block reached.");
                        WriteLine($"in nested index, e.message is {e.Message}" );
                        // throw new SystemException(); // 即使是throw,也是先执行这里的finally
                        throw; // 注意throw的抛出异常的类型
                    }
                    finally
                    {
                        WriteLine("ThrowException(\"nested index\") finally"
                                  + " block reached.");
                    }
                    break;
                case "filter":
                    try // Line 86
                    {
                        WriteLine("ThrowException(\"filter\") " +
                                  "try block reached.");
                        WriteLine("ThrowException(\"index\") called.");
                        ThrowException("index"); // Line 91
                    }
                    catch // Line 93
                    {
                        WriteLine("ThrowException(\"filter\") general"
                                  + " catch block reached.");
                        throw;
                    }
                    break;
            }
        }
    }
}