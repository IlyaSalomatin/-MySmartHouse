using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace MySmartHouse
{
    public class Kitchen:Room,IBoiler,IFloorHeating,IOzonation,IAirConditioning,IThermometer,ISmartWindow
    {
        public bool FrostedGlassState { get; set; }
        public byte DimmingGlass { get; set; }
        public byte TempConditioning { get; set; }
        public bool ConditioningState { get; set; }
        public Heating boiler { get; set; }
        public Heating floorHeating { get; set; }
        public double Temperature { get; set; }
        public byte Humidity { get; set; }
        public TimerOzonation OzonationState { get; set; }
        public Kitchen (string name, double temperature, byte humidity): base (name)
        {
            Temperature = temperature;
            Humidity = humidity;
        }
        public void SetTimerOzonation(TimerOzonation v)
        {
            OzonationState = v;
            Task t = new Task(Timer);
            t.Start();
        }
        void Timer()
        {
            int time = (int)OzonationState;
            Thread.Sleep(time);
            OzonationState = TimerOzonation.Off;
        }
        public void OnConditioning(byte t)
        {
            ConditioningState = true;
            TempConditioning = t;

        }
        public void OffConditioning()
        {
            ConditioningState = false;
        }
        public void FrostedGlassOnOff()
        {
            FrostedGlassState = FrostedGlassState == true ? FrostedGlassState = false : FrostedGlassState = true;
        }
        public void SetDimmingGlass(byte p)
        {
            DimmingGlass = p;
        }

    }
}
