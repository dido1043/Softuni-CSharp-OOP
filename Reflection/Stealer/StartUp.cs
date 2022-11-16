using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.StealFieldInfo(typeof(Hacker).FullName, "username", "password");
            result = spy.AnalyzeAccessModifiers(typeof(Hacker).FullName);
            result = spy.RevealPrivateMethods(typeof(Hacker).FullName);
            result = spy.CollectGettersAndSetters(typeof(Hacker).FullName);
            Console.WriteLine(result);
        }
    }
}
