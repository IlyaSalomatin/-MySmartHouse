using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MySmartHouse
{
    public class BathRoom : Room,IOzonation,IFloorHeating,ISmartWindow,IBoiler
    {
        public bool FrostedGlassState { get; set; }
        public byte DimmingGlass { get; set; }
        public BathRoom(string name) : base(name) { }
        public Heating FloorHeating { get; set; }
        public Heating Boiler { get; set; }
        public TimerOzonation OzonationState { get; set; }
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
