using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MySmartHouse
{
    public class Hall:Room,IOzonation,IThermometer,IFloorHeating
    {
        public Heating FloorHeating { get; set; }
        public double Temperature { get; set; }
        public byte Humidity { get; set; }
        public TimerOzonation OzonationState { get; set; }
        public Hall (string name, double temperature, byte humidity): base (name)
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



    }
}
