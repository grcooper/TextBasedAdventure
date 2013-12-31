using System;
using System.Collections.Generic;
using System.Text;

namespace BattleSystem_Final
{
    class MainGame
    {
        List<Character> Monster;
        DataHandler data = new DataHandler();
        Hero myhero;
        Battle battle;
        string answer;

        //Game loop.
        public MainGame()
        {
            Console.WriteLine("Welcome to the arena!");
            myhero = new Hero();//Creates your hero.
            Hero.Initialize(myhero);//Initializes the hero.
            Monster = new List<Character>();//Creates monster list, to keep track of monsters you are fighting.
            Console.Clear();
            BasicGameLoop();//Initializes the Basic Game Loop (the Battle Loop)
        }
        void BasicGameLoop()//Basic Game execution
        {
            do
            {
                Monster.Clear();
                Console.WriteLine();//Writes out the option screen.
                Console.Write(@"
What would you like to do?
_____________________________
(F)ight
(S)tore
(I)nn
(V)iew
(L)oad
s(A)ve
(Q)uit
_____________________________
F,S,I,V,L,A or Q?");
                Console.WriteLine();
                answer = Console.ReadLine();
                Console.WriteLine();
                switch (answer)//Accepts a choice.
                {
                    case "L":
                    case "l":
                        data.Load(myhero);
                        break;
                    case "A":
                    case "a":
                        data.Save(myhero);
                        break;
                    case "S":
                    case "s":
                        Store store = new Store(myhero);//Initializes the store
                        break;
                    case "I":
                    case "i":
                        Inn.Sleep(myhero);//Initializes the Inn
                        break;
                    case "v":
                    case "V":
                        View.PrintStats(myhero);//Prints character info
                        break;
                    case "F":
                    case "f":
                        string done = "";
                        Console.Clear();
                        do//Asks what monster character would like to fight.
                        {
                            Console.Write(@"
Which monster do you want to fight?
(S)lime:
(B)arbarian:
(M)age:
_________________________");

                            Console.WriteLine();
                            string choice = Console.ReadLine();//Accepts choice

                            if (choice == "S" || choice == "s")
                            {
                                Monster.Add(new Slime());//Adds slime to monster list.
                            }

                            else if (choice == "B" || choice == "b")
                            {
                                Monster.Add(new Barbarian());//Adds barbarian to monster list.
                            }

                            else if (choice == "M" || choice == "m")
                            {
                                Monster.Add(new Mage());//Adds mage to monster list.
                            }

                            else
                            {
                                Monster.Add(new Slime());
                            }
                            Console.WriteLine("Would you like to fight more monsters? (Y/N)");
                            Console.WriteLine();
                            done = Console.ReadLine();
                            Console.Clear();
                        }
                        while (done == "Y" || done == "y");
                        battle = new Battle(myhero, Monster);

                        if (myhero.CurrentHealth <= 0)
                        {
                            Console.WriteLine("Your game is over!");
                            Console.WriteLine("Would you like to load your last save? (Y/N)");
                            String Choice = Console.ReadLine();
                            if (Choice == "Y" || Choice == "y")
                            {
                                data.Load(myhero);
                            }
                            else
                            {
                                Environment.Exit(0);
                            }
                            continue;
                        }
                        else if (myhero.fled == false)
                        {
                            int gold = 0;
                            int experience = 0;
                            foreach (Character monster in Monster)
                            {
                                if (monster.fled == false)
                                {
                                    experience += monster.Experience;
                                    gold += monster.Gold;
                                }
                            }
                            Console.WriteLine("{0} gets {1} gold and {2} experience"
                                , myhero.Identifier, gold, experience);
                            myhero.Experience += experience;
                            myhero.Gold += gold;
                            Monster.Clear();
                            BattleHelper.LevelUp(myhero);
                            Console.WriteLine("Press enter to continue....");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            myhero.fled = false;
                        }
                        break;
                    case "Q":
                    case "q":
                        Console.WriteLine("Goodbye {0}", myhero.Identifier);
                        break;
                }
            }
            while (answer != "Q" && answer != "q");
        }
    }
}