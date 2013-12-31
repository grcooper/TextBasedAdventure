using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssassinEngine
{
    class Battle
    {
        string userspellchoice;
        string userchoice;
        string monsterchoice;
        string monsterspellchoice;
        int targetmonster;
        bool amonsterleft;

        public Battle(Hero hero, List<Character> monsters)
        {
            Console.WriteLine("{0} is facing:", hero.Identifier);
            foreach (Character monster in monsters)
            {
                Console.WriteLine("{0}", monster.Identifier);
            }
            BattleLoop(hero, monsters);
        }
        public void BattleLoop(Hero hero, List<Character> monsters)
        {
            do
            {
                if (hero.CurrentMagic < hero.MaxMagic)
                {
                    hero.CurrentMagic += 1;
                }


                Console.WriteLine("********************************");
                BattleHelper.PrintStatus(hero);
                foreach (Character monster in monsters)
                {
                    if (monster.isAlive)
                        BattleHelper.PrintStatus(monster);
                }
                userchoice = BattleHelper.PrintChoice();

                Console.WriteLine();
                BattleHelper.CheckDefence(userchoice, hero);
                if (userchoice == "s" || userchoice == "S")
                {
                    userspellchoice = BattleHelper.PrintSpells();
                }
                //else if (userchoice == "f" || userchoice == "F")
                //{
                //    Console.WriteLine("You have fled");
                //    Console.WriteLine("Press any key to continue");
                //    Console.ReadKey();
                //    hero.fled = true;
                //    Console.Clear();
                //    continue;
                //}
                targetmonster = BattleHelper.ChooseTarget(monsters);
                BattleHelper.ProcessChoice(userchoice, hero, monsters[targetmonster], userspellchoice);

                foreach (Character monster in monsters)
                {
                    monster.isAlive = BattleHelper.CheckHealth(monster.CurrentHealth);
                    if (monster.isAlive == true)
                    {
                        monsterchoice = monster.AI();
                        BattleHelper.CheckDefence(monsterchoice, monster);
                        if (monsterchoice == "S" || monsterchoice == "s")
                        {
                            monsterspellchoice = monster.SpellAI();
                        }

                        BattleHelper.ProcessChoice(monsterchoice, monster, hero, monsterspellchoice);
                    }
                }
                amonsterleft = BattleHelper.CheckMonsters(monsters);
                Console.WriteLine("Press enter to continue.....");
                Console.ReadLine();
                Console.Clear();

                if (hero.CurrentHealth <= 0)
                {
                    hero.isAlive = false;
                }
                

            }
            while (hero.isAlive == true && amonsterleft == true);
        }
    }

}
