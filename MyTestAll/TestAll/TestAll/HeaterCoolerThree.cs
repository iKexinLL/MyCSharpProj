using System;

namespace TestAll
{
    class HeaterCoolerThree
    {
        public class TemperatureArgs : System.EventArgs
        {
            private float _newTemperature;

            public TemperatureArgs(float newTemperature)
            {
                NewTemperature = newTemperature;
            }

            // ReSharper disable once ConvertToAutoProperty
            public float NewTemperature
            {
                get => _newTemperature;
                set => _newTemperature = value;
            }
        }

        public event EventHandler<TemperatureArgs> OnTemperatureChange = delegate { };

        public float CurrentTemperature
        {
            get => _currentTemperature;
            set
            {
                if (Math.Abs(value - CurrentTemperature) > 0)
                {
                    _currentTemperature = value;

                    OnTemperatureChange?.Invoke(this, new TemperatureArgs(value));
                }
            }
        }

        private float _currentTemperature;

    }
}
