using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test201907.CookByAsyncAwait
{
    public abstract class BaseFood
    {
        public string Name { get; }
        public int Cooktime { get; }
        public bool IsCookFinished { get; private set; }

        public BaseFood(string name, int cooktime)
        {
            Name = name;
            Cooktime = cooktime;
            IsCookFinished = false;
        }    
        public void PrintInfo(string message)
        {
            System.Console.WriteLine(message);
        }

        public bool CookNormal()
        {
            PrintInfo($"{Name} is cooking...");
            Thread.Sleep(Cooktime * 1000);
            IsCookFinished = true;
            PrintInfo($"After {Cooktime}s, {Name} finished.");
            return IsCookFinished;
        }

        public async Task CookByTask()
        {
            PrintInfo($"{Name} is cooking...");
            // TODO: await之后,就结束了, 不会运行后面的代码 -> 这句话有问题, 需要在讨论
            await Task.Delay(Cooktime * 1000);
            IsCookFinished = true;
            PrintInfo($"After {Cooktime}s, {Name} finished.");
        }        
    }
}