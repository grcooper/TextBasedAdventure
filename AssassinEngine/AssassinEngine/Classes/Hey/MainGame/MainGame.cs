using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssassinEngine
{
    class MainGame
    {
        //Game loop.
        public MainGame(Hero myhero, List<Character> Monster)
        {
            Console.WriteLine("Welcome.");
            myhero = new Hero();//Creates your hero.
            Hero.Initialize(myhero);//Initializes the hero.
            Monster = new List<Character>();//Creates monster list, to keep track of monsters you are fighting.
            Console.Clear();
        }
    }
}