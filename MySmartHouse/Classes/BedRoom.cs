using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MySmartHouse
{
    public class BedRoom : Room,IThermometer,IAirConditioning,IAirHumidification,IFloorHeating,ISmartWindow,IOzonation
    {
        public bool FrostedGlassState { get; set; }
        public byte DimmingGlass { get; set; }
        public byte TempConditioning { get; set; }
        public bool ConditioningState { get; set; }
        public Heating FloorHeating { get; set; }
        public double Temperature { get; set; }
        public byte Humidity { get; set; }
        public TimerOzonation OzonationState { get; set; }
        public TimerHumidification HumidificationState { get; set; }
        public BedRoom (string name, double temperature, byte humidity): base (name)
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
        public void SetTimerHumidification(TimerHumidification time)
        {
            
            HumidificationState = time;
            Task t = new Task(TimerHum);
            t.Start();
            
        }
        void TimerHum()
        {
            int time = (int)HumidificationState;
            Thread.Sleep(time);
            HumidificationState = TimerHumidification.Off;
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
