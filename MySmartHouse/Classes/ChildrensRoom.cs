using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MySmartHouse
{
    public class ChildrensRoom : Room,IAirConditioning,IAirHumidification,ISmartWindow,IFloorHeating,IOzonation,IThermometer
    {
        public bool FrostedGlassState { get; set; }
        public byte DimmingGlass { get; set; }
        public byte TempConditioning { get; set; }
        public bool ConditioningState { get; set; }
        public Heating floorHeating { get; set; }
        public double Temperature { get; set; }
        public byte Humidity { get; set; }
        public TimerOzonation OzonationState { get; set; }
        public TimerHumidification HumidificationState { get; set; }
        public ChildrensRoom (string name, double temperature, byte humidity): base (name)
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
        public void SetTimerHumidification(TimerHumidification v)
        {
            HumidificationState = v;
            Task t = new Task(TimerHum);
            t.Start();
        }
        void TimerHum()
        {
            int time = (int)HumidificationState;
            Thread.Sleep(time);
            HumidificationState = TimerHumidification.Off;
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
