namespace BorderControl.Core
{
    using BorderControl.Models;
    using BorderControl.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine : IEngine
    {
        //Logic of the problem
        private List<IIdentify> idList;
        public Engine()
        {

        }
        public void RunEngine()
        {
            string command = Console.ReadLine();
            this.idList = new List<IIdentify>();
            while (command != "End")
            {
                var intoArr = command.Split(" ");

                if (intoArr.Length == 3)
                {
                    var name = intoArr[0];
                    var age = int.Parse(intoArr[1]);
                    var id = intoArr[2];

                    Citizen citizen = new Citizen(name, age, id);
                    this.idList.Add(citizen);
                }
                else
                {
                    var modelOfRobot = intoArr[0];
                    var id = intoArr[1];
                    Robot robot = new Robot(modelOfRobot, id);
                    this.idList.Add(robot);
                }
                command = Console.ReadLine();
            }
            var endingNum = Console.ReadLine();

            this.idList.Where(c => c.ID.EndsWith(endingNum))
            .Select(c => c.ID)
            .ToList()
            .ForEach(Console.WriteLine);
        }
    }
}
