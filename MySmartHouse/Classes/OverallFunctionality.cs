using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MySmartHouse
{
    public class OverallFunctionality:Room,IBlinds,ILighting,IPower,IAlarmSystem
    {
        public Power powerState { get; set; }
        public Lighting lightingState { get; set; }
        public string AlarmSystemState { get; set; }
        public string Blinds { get; set; }
        public OverallFunctionality(string name) : base(name) 
        {
            AlarmSystemState = "Off";
            Blinds = "raised";
        }
        public void GetLoweredBlinds()
        {
            Blinds = "lowered";
        }
        public void GetRaisedBlinds()
        {
            Blinds = "raised";
        }
        public void ChangeAlarmSystemState()
        {
            string re = @"^0000$";
            while (true)
            {
                Console.WriteLine("Enter your password:");
                string password = Console.ReadLine();
                if (Regex.IsMatch(password, re, RegexOptions.IgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong password!!!");
                    Console.ResetColor();
                }
            }
            AlarmSystemState = AlarmSystemState == "On" ? AlarmSystemState = "Off" : AlarmSystemState = "On";

        }


















    }
}
