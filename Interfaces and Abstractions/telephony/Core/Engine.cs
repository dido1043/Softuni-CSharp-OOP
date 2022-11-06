using System;
using System.Collections.Generic;
using System.Text;
using telephony.Models;
using telephony.Models.Interfaces;

namespace telephony.Core
{
    public class Engine:IEngine
    {
        private readonly string[] phones;
        private readonly string[] URLs;

        private readonly IStationaryPhone stationaryPhone;
        private readonly ISmartPhone smartphone;
        private Engine()
        {
            stationaryPhone = new StationaryPhone();
            smartphone = new Smartphone();
        }

        public Engine(string[] phonesArr, string[] URL) : this()
        {
            phones = phonesArr;
            URLs = URL;
        }


        public void RunEngine()
        {
            foreach (var item in this.phones)
            {
                try
                {
                    if (item.Length == 10)
                    {
                        Console.WriteLine(smartphone.Call(item));                        
                    }
                    else if (item.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(item));                        
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (var url in this.URLs)
            {
                try
                {
                    Console.WriteLine(smartphone.Browsing(url));
                    
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Invalid URL!"); 
                }
            }

        }

    }
}
