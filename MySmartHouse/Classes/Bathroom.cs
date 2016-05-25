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
        public Heating floorHeating { get; set; }
        public Heating boiler { get; set; }
        public TimerOzonation OzonationState { get; set; }
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
