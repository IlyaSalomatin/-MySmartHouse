using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySmartHouse
{
    public class Menu
    {
        Room[] Rooms = new Room[7];

        public void StartProject()
        {

            Rooms[0] = new OverallFunctionality("overallFunc");
            Rooms[1] = new BedRoom("bedroom", 17, 70);
            Rooms[2] = new ChildrensRoom("childrensroom", 16.5, 73);
            Rooms[3] = new LivingRoom("livingloom", 17.5, 65);
            Rooms[4] = new Hall("hall", 17.5, 65);
            Rooms[5] = new BathRoom("bathroom");
            Rooms[6] = new Kitchen("kitchen", 19, 70);

            while (true)
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\r{0}", DateTime.Now);
                Console.WriteLine();
                Console.WriteLine("Blinds state:  " + ((IBlinds)Rooms[0]).Blinds + "       " + "Mode of lightin :  " + ((ILighting)Rooms[0]).LightingState);
                Console.Write("Alarmsustem :  ");
                if (((IAlarmSystem)Rooms[0]).AlarmSystemState == "On")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(((IAlarmSystem)Rooms[0]).AlarmSystemState + "          ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(((IAlarmSystem)Rooms[0]).AlarmSystemState + "          ");
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Mode of power   :  ");
                if (((IPower)Rooms[0]).PowerState == Power.CommercialPower)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(((IPower)Rooms[0]).PowerState);
                }
                else if (((IPower)Rooms[0]).PowerState == Power.EmergencyGenerator)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(((IPower)Rooms[0]).PowerState);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(((IPower)Rooms[0]).PowerState);
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("Rooms:");
                for (int i = 1; i < Rooms.Length; i++)
                {
                    Console.WriteLine(i + "---" + Rooms[i].Name);
                }
                Console.WriteLine();
                Console.WriteLine("Commands : ()--[ignoreCase]");
                Console.WriteLine();
                Console.WriteLine("Choose a room :  Enter a number from 1 to 6.");
                Console.WriteLine("Blinds : to raised -(BR); to lowered -(BL). ");
                Console.WriteLine("Alarm system : (ALARM)");
                Console.WriteLine("Lightin : Mechanical Switch -(SW);  Motion Sensor -(SN); Spoken Commands -(SP).");
                Console.WriteLine("Power : Commercial -(COM);  Alternative -(ALT);  EmergencyGenerator -(GEN).");
                Console.WriteLine("Press (X) to exit.");
                Console.ResetColor();
                if (((IAlarmSystem)Rooms[0]).AlarmSystemState == "On")
                {
                    while (true)
                    {
                        Console.WriteLine("Alarm is enabled, control is locked!!!  Press (X) to exit or press (ALARM). ");
                        string com = Console.ReadLine();
                        com.ToLower();
                        if (com == "x")
                        {
                            return;
                        }
                        else if (com == "alarm")
                        {
                            ((IAlarmSystem)Rooms[0]).ChangeAlarmSystemState();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("<<incorrect command>>");
                        }
                    }
                }
                Console.Beep();
                Console.Write("Please enter the command -  ");
                string command = Console.ReadLine();
                command.ToLower();
                switch (command)
                {
                    case "bl":
                        {
                            ((IBlinds)Rooms[0]).GetLoweredBlinds();
                        }
                        break;
                    case "br":
                        {
                            ((IBlinds)Rooms[0]).GetRaisedBlinds();
                        }
                        break;
                    case "alarm":
                        {
                            ((IAlarmSystem)Rooms[0]).ChangeAlarmSystemState();
                        }
                        break;
                    case "com":
                        {
                            ((IPower)Rooms[0]).PowerState = Power.CommercialPower;
                        }
                        break;
                    case "alt":
                        {
                            ((IPower)Rooms[0]).PowerState = Power.AlternativePower;
                        }
                        break;
                    case "gen":
                        {
                            ((IPower)Rooms[0]).PowerState = Power.EmergencyGenerator;
                        }
                        break;
                    case "sw":
                        {
                            ((ILighting)Rooms[0]).LightingState = Lighting.MechanicalSwitch;
                        }
                        break;
                    case "sn":
                        {
                            ((ILighting)Rooms[0]).LightingState = Lighting.MotionSensor;
                        }
                        break;
                    case "sp":
                        {
                            ((ILighting)Rooms[0]).LightingState = Lighting.SpokenCommands;
                        }
                        break;
                    case "1":
                        {
                            OptionsRooms(Rooms[1]);
                        }
                        break;
                    case "2":
                        {
                            OptionsRooms(Rooms[2]);
                        }
                        break;
                    case "3":
                        {
                            OptionsRooms(Rooms[3]);
                        }
                        break;
                    case "4":
                        {
                            OptionsRooms(Rooms[4]);
                        }
                        break;
                    case "5":
                        {
                            OptionsRooms(Rooms[5]);
                        }
                        break;
                    case "6":
                        {
                            OptionsRooms(Rooms[6]);
                        }
                        break;
                    case "x":
                        return;
                    default:
                        Console.Write("<<Incorrect command, press Enter-please>>");
                        Console.ReadLine();
                        break;
                }
            }
        }
        private void OptionsRooms(Room r)
        {
            
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\r{0}", DateTime.Now);
                Console.WriteLine("");
                Console.Write("You choosed : " + r.Name + "---");
                if (r is IThermometer)
                {
                    Console.WriteLine("    temp = "+((IThermometer)r).Temperature+" 'C     "+"f = "+((IThermometer)r).Humidity+"%.");
                }
                else
                {
                    Console.WriteLine("");
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("");
                Console.WriteLine("Available devices :");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("");
                if (r is IFloorHeating)
                {
                    Console.WriteLine("FloorHeating : "+ ((IFloorHeating)r).FloorHeating+".");
                }
                if (r is ISmartWindow)
                {
                    Console.WriteLine("SmartWindow : FrostedGlass - "+((ISmartWindow)r).FrostedGlassState + "  /  DimmingGlass - "+((ISmartWindow)r).DimmingGlass+"%.");
                }
                if (r is IAirConditioning)
                {
                    Console.Write("AirConditioning :  State - "+((IAirConditioning)r).ConditioningState);
                    if (((IAirConditioning)r).ConditioningState == true)
                    {
                        Console.WriteLine("  /  Temperature - "+((IAirConditioning)r).TempConditioning+" 'C.");
                    }
                    else
                    {
                        Console.WriteLine(".");
                    }
                }
                if (r is IAirHumidification)
                {
                    Console.WriteLine("AirHumidification : "+((IAirHumidification)r).HumidificationState+".");
                }
                if (r is IOzonation)
                {
                    Console.WriteLine("Ozonation : "+((IOzonation)r).OzonationState+".");
                }
                if (r is IBoiler)
                {
                    Console.WriteLine("Boiler's mode : "+((IBoiler)r).Boiler+".");
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Commands : ()--[ignoreCase]");
                if (r is IFloorHeating)
                {
                    Console.WriteLine("FloorHeating : (FH0),(FH1),(FH2),(FH3),(FH4).");
                }
                if (r is IBoiler)
                {
                    Console.WriteLine("Boiler : (B0),(B1),(B2),(B3),(B4).");
                }
                if (r is IOzonation)
                {
                    Console.WriteLine("Ozonation : Off-(OZOF), TwoMinutes-(OZ2), FiveMinutes-(OZ5), TenMinutes-(OZ10).");
                }
                if (r is IAirHumidification)
                {
                    Console.WriteLine("AirHumidification : Off-(HOF), HolfHour-(H30M),  OneHour-(H1), TwoHours-(H2).");
                }
                if (r is IAirConditioning)
                {
                    Console.WriteLine("AirConditioning :  Off - (ACOF), On - (ACON). ");
                }
                if (r is ISmartWindow)
                {
                    Console.WriteLine("SmartWindow : FrostedGlassState - (FGS), SetDimmingGlass - (SDG).");
                }
                Console.WriteLine("Back to main menu - press (0). ");
                Console.ResetColor();
                Console.Write("Please enter the command -  ");
                Console.Beep();
                string command = Console.ReadLine();
                command.ToLower();
                switch (command)
                {
                    case "fh0":
                        {
                            ((IFloorHeating)r).FloorHeating = Heating.off;
                        }
                        break;
                    case "fh1":
                        {
                            ((IFloorHeating)r).FloorHeating = Heating.low;
                        }
                        break;
                    case "fh2":
                        {
                            ((IFloorHeating)r).FloorHeating = Heating.medium;
                        }
                        break;
                    case "fh3":
                        {
                            ((IFloorHeating)r).FloorHeating = Heating.high;
                        }
                        break;
                    case "fh4":
                        {
                            ((IFloorHeating)r).FloorHeating = Heating.max;
                        }
                        break;
                    case "b0":
                        {
                            ((IBoiler)r).Boiler = Heating.off;
                        }
                        break;
                    case "b1":
                        {
                            ((IBoiler)r).Boiler = Heating.low;
                        }
                        break;
                    case "b2":
                        {
                            ((IBoiler)r).Boiler = Heating.medium;
                        }
                        break;
                    case "b3":
                        {
                            ((IBoiler)r).Boiler = Heating.high;
                        }
                        break;
                    case "b4":
                        {
                            ((IBoiler)r).Boiler = Heating.max;
                        }
                        break;
                    case "ozof":
                        {
                            ((IOzonation)r).SetTimerOzonation(TimerOzonation.Off);
                        }
                        break;
                    case "oz2":
                        {
                            ((IOzonation)r).SetTimerOzonation(TimerOzonation.TwoMinutes);
                        }
                        break;
                    case "oz5":
                        {
                            ((IOzonation)r).SetTimerOzonation(TimerOzonation.FiveMinutes);
                        }
                        break;
                    case "oz10":
                        {
                            ((IOzonation)r).SetTimerOzonation(TimerOzonation.TenMinutes);
                        }
                        break;
                    case "hof":
                        {
                            ((IAirHumidification)r).SetTimerHumidification(TimerHumidification.Off);
                        }
                        break;
                    case "h30m":
                        {
                            ((IAirHumidification)r).SetTimerHumidification(TimerHumidification.HolfHour);
                        }
                        break;
                    case "h1":
                        {
                            ((IAirHumidification)r).SetTimerHumidification(TimerHumidification.OneHour);
                        }
                        break;
                    case "h2":
                        {
                            ((IAirHumidification)r).SetTimerHumidification(TimerHumidification.TwoHours);
                        }
                        break;
                    case "acof":
                        {
                            ((IAirConditioning)r).OffConditioning();
                        }
                        break;
                    case "fgs":
                        {
                            ((ISmartWindow)r).FrostedGlassOnOff();
                        }
                        break;
                    case "acon":
                        {
                           Console.Write("Enter an integer from 15 to 25 : ");
                           try 
	                          {	        
		                        byte x = byte.Parse(Console.ReadLine());
                                if (x<=25 && x>=5 )
                                {
                                  ((IAirConditioning)r).OnConditioning(x);
                                }
	                          }
	                       catch (Exception)
	                          {
		                       Console.ForegroundColor = ConsoleColor.Red; 
                               Console.Write("<<Incorrect command, press Enter-please!!!>>");
                               Console.ResetColor();
                               Console.ReadLine();
	                          }
                            
                        }
                        break;
                    case "sdg":
                        {
                            Console.Write("Enter an integer from 0 to 85 : ");
                            try
                            {
                                byte x = byte.Parse(Console.ReadLine());
                                if (x <= 85 && x >= 0)
                                {
                                    ((ISmartWindow)r).SetDimmingGlass(x);
                                }
                            }
                            catch (Exception)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("<<Incorrect command, press Enter-please!!!>>");
                                Console.ResetColor();
                                Console.ReadLine();
                            }
                        }
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("<<Incorrect command, press Enter-please>>");
                        Console.ReadLine();
                        break;
                        //The end!!!!!!
                }


               
            
            
            }




        }




    }
}
