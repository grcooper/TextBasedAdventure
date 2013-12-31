using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssassinEngine
{
    class Program
    {
        public static bool quit;
        
        static void Main(string[] args)
        {
            Calculator.DisplayTime();
            List<Character> Monster;
            DataHandler data = new DataHandler();
            Hero myhero;
            myhero = new Hero();//Creates your hero.
            Hero.Initialize(myhero);//Initializes the hero.
            Monster = new List<Character>();
            GameManager.ShowTitleScreen();
            Level.Initialize(myhero, Monster);
            GameManager.StartGame();
            //our main game loop that tells us as long as we are not quiting, the program asks us for a command.
            while (!quit)
            {
                CommandProcessor.ProcessCommand(Console.ReadLine(), myhero);
            }
        }
    }
}
