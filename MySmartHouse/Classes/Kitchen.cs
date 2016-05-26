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
        public Heating Boiler { get; set; }
        public Heating FloorHeating { get; set; }
        public double Temperature { get; set; }
        public byte Humidity { get; set; }
        public TimerOzonation OzonationState { get; set; }
        public Kitchen (string name, double temperature, byte humidity): base (name)
        {
            Temperature = temperature;
            Humidity = humidity;
        }
        public void SetTimerOzonation(TimerOzonation time)
        {
            OzonationState = time;
            Task t = new Task(TimerOzon);
            t.Start();
        }
        void TimerOzon()
        {
            int time = (int)OzonationState;
            Thread.Sleep(time);
            OzonationState = TimerOzonation.Off;
        }
        public void OnConditioning(byte temp)
        {
            ConditioningState = true;
            TempConditioning = temp;

        }
        public void OffConditioning()
        {
            ConditioningState = false;
        }
        public void FrostedGlassOnOff()
        {
            FrostedGlassState = FrostedGlassState == true ? FrostedGlassState = false : FrostedGlassState = true;
        }
        public void SetDimmingGlass(byte percent)
        {
            DimmingGlass = percent;
        }

    }
}
