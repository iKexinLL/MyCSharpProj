using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAll
{
    class HeaterCoolerOther
    {
        public Action<float> OnTemperatureChange { get; set; }

        public float CurrentTemperature
        {
            get => _currentTemperature;
            set
            {
                if (Math.Abs(value - CurrentTemperature) > 0)
                {
                    _currentTemperature = value;

                    // 需要如果在添加委托之间赋值,那么对于OnTemperatureChange为null=>报错
                    // 所以需要在+=之后调用赋值
                    // 但仍需要检测null值
                    // 为什么要创建新的localOnChange?
                    // 为了多线程中的安全
                    // 否则可以使用简化版本 OnTemperatureChange?.Invoke(value);
                    Action<float> localOnChange = OnTemperatureChange;
                    // ReSharper disable once UseNullPropagation
                    if (localOnChange != null)
                        localOnChange(value);
                }
            }
        }

        private float _currentTemperature;
    }


    class Cooler
    {
        public Cooler(float temperature)
        {
            Temperature = temperature;
        }

        public float Temperature { get; set; }

        public void OnTemperatureChanged(float newTemperature)
        {
            Console.WriteLine(newTemperature > Temperature ? "Cooler: On" : "Cooler: Off");
        }

        public void OnTemperatureChanged(object sender, HeaterCoolerThree.TemperatureArgs e)
        {
            Console.WriteLine(e.NewTemperature > Temperature ? "Cooler: On" : "Cooler: Off");
        }
    }

    class Heater
    {
        public Heater(float temperature)
        {
            Temperature = temperature;
        }

        public float Temperature { get; set; }

        public void OnTemperatureChanged(float newTemperature)
        {
            Console.WriteLine(newTemperature < Temperature ? "Heater: On" : "Heater: Off");
        }

        public void OnTemperatureChanged(object sender, HeaterCoolerThree.TemperatureArgs e)
        {
            Console.WriteLine(e.NewTemperature < Temperature ? "Heater: On" : "Heater: Off");
        }
    }
}
