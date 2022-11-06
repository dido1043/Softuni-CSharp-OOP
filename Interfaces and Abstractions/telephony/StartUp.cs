namespace telephony
{
    using System;
    using System.Dynamic;
    using telephony.Core;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var phonesArr = Console.ReadLine().Split(" ");
            var urlArr = Console.ReadLine().Split(" ");
            IEngine engine = new Engine(phonesArr, urlArr);

            engine.RunEngine();
        }
    }
}