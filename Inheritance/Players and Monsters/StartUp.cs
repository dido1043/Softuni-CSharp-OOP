using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Hero hero  = new Hero("Mordor", 50);

            Console.WriteLine(hero);
            BladeKnight bk = new BladeKnight("Hamid", 25);
            Console.WriteLine(bk);

        }
    }
}
