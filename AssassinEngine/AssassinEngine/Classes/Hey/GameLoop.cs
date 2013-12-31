using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssassinEngine
{
    class GameLoop
    {
        public void BasicGameLoop(Hero myhero, List<Character> Monster, Battle battle)//Basic Game execution
        {
       
        battle = new Battle(myhero, Monster);

        if (myhero.CurrentHealth <= 0)
        {
        TextBuffer.Add("Your game is over!");
        Console.ReadLine();
        Environment.Exit(0);   
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
                        Console.WriteLine("Goodbye {0}", myhero.Identifier);
                }
        }
    }


