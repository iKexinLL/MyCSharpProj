using System;
using System.Diagnostics;
using System.Reflection;
// 
namespace MyTest
{
    public partial class ReflectionTest2
    {
        public static void TestStart()
        {
            var strs = new string[] {"/help", @"/out:E:\xkx\OnGit\MyCSharpProj\201907Test\Program.cs", "/Priority:Idle"};
            TestStart(strs);
            
            var strs2 = new string[] {@"/out:E:\xkx\OnGit\MyCSharpProj\201907Test\Program.cs", "/Priority:Idle"};
            TestStart(strs2);
            
            var strs3 = new string[] {"/Priority:Idle"};
            TestStart(strs3);
        }
        // in main method: ReflectionTest2.TestStart(new string[] {"/help", "/out"});
        public static void TestStart(string[] args)
        {
            foreach (var i in args)
            {
                Console.Write(i + ";");
            }
            Console.WriteLine();

            string errorMessage;

            CommandLineInfo commandLine = new CommandLineInfo();

            if (!CommandLineInfoHandler.TryParse(args, commandLine, out errorMessage))
            {
                Console.WriteLine(errorMessage);
                DisplayHelp();
            }

            if (commandLine.Help)
            {
                DisplayHelp();
            }
            else
            {
                if (commandLine.Priority != ProcessPriorityClass.Normal)
                {
                    Console.WriteLine(@"this is commandLine.Priority: {commandLine.Priority}");
                }
            }
        }

        private static void DisplayHelp()
        {
            // Display the command-line help
            Console.WriteLine("this is DisplayHelp()");
        }
    }

    public partial class ReflectionTest2
    {
        private class CommandLineInfo
        {
            private ProcessPriorityClass _Priority = ProcessPriorityClass.Normal;

            public bool Help { get; set; }
            public string Out { get; set; }

            public ProcessPriorityClass Priority
            {
                get { return _Priority; }
                set { _Priority = value; }
            }
        }
    }

    public class CommandLineInfoHandler
    {
        public static void Parse(string[] args, object commandLine)
        {
            string errorMessage;
            if (!TryParse(args, commandLine, out errorMessage))
            {
                throw new ApplicationException(errorMessage);
            }
        }

        public static bool TryParse(string[] args, object commandLine, out string errorMessage)
        {
            bool success = false;
            errorMessage = null;
            
            foreach (string arg in args)
            {
                string option;
                if (arg[0] == '/' || arg[0] == '-')
                {
                    string[] optionParts = arg.Split(new char[] {':'}, 2);

                    option = optionParts[0].Remove(0, 1);

                    PropertyInfo property = 
                        commandLine.GetType().GetProperty(option,
                            BindingFlags.IgnoreCase |
                            BindingFlags.Instance |
                            BindingFlags.Public);
                    
                    if (property != null)
                    {
                        if (property.PropertyType == typeof(bool))
                        {
                            property.SetValue(commandLine, true, null);
                            success = true;
                        }
                        else if (property.PropertyType == typeof(string))
                        {
                            property.SetValue(commandLine, optionParts[1], null);
                            success = true;
                        }
                        else if (property.PropertyType.IsEnum)
                        {
                            try
                            {
                                property.SetValue(commandLine, 
                                    Enum.Parse(
                                        typeof(ProcessPriorityClass),
                                        optionParts[1], true), null);
                            }
                            catch (ArgumentException)
                            {
                                success = false;
                                errorMessage = $"The option '{optionParts[1]}' is " +
                                            $"invalid for '{option}' ";
                            }
                        }
                        else
                        {
                            success = false;
                            errorMessage = $"Data type {property.PropertyType.ToString()}" + 
                                        $" on {commandLine.GetType().ToString()} is not supported.";
                        }
                    }
                    else
                    {
                        success = false;
                        errorMessage = $"Option '{option}' is not supported";
                    }
                }
            }
            return success;
        }
    }
}