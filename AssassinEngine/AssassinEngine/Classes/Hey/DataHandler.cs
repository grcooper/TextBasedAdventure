using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AssassinEngine
{

    public class DataHandler
    {
        public DataHandler()
        {

        }

        public void Save(Hero hero)
        {
            if (Directory.Exists(@"c:\SaveRPG") == false)
            {
                Directory.CreateDirectory(@"c:\SaveRPG");
            }
            StreamWriter file = new StreamWriter(@"c:\SaveRPG\PlayerData.txt");

            file.WriteLine(hero.CurrentHealth);
            file.WriteLine(hero.MaxHealth);
            file.WriteLine(hero.CurrentMagic);
            file.WriteLine(hero.MaxMagic);
            file.WriteLine(hero.Strength);
            file.WriteLine(hero.Defense);
            file.WriteLine(hero.Dexterity);
            file.WriteLine(hero.Experience);
            file.WriteLine(hero.Gold);
            file.WriteLine(hero.AttackDamage);
            file.WriteLine(hero.Identifier);

            foreach (string item in hero.items)
            {
                file.WriteLine(item);
            }

            file.Close();
            Console.WriteLine("Game Save successful");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();

            
        }



        public void Load(Hero hero)
        {
            bool done = false;
            string item;
            StreamReader file = new StreamReader(@"c:\SaveRPG\PlayerData.txt");
            hero.CurrentHealth = int.Parse(file.ReadLine());
            hero.MaxHealth = int.Parse(file.ReadLine());
            hero.CurrentMagic = int.Parse(file.ReadLine());
            hero.MaxMagic = int.Parse(file.ReadLine());
            hero.Strength = int.Parse(file.ReadLine());
            hero.Defense = int.Parse(file.ReadLine());
            hero.Dexterity = int.Parse(file.ReadLine());
            hero.Experience = int.Parse(file.ReadLine());
            hero.Gold = int.Parse(file.ReadLine());
            hero.AttackDamage = int.Parse(file.ReadLine());
            hero.Identifier = file.ReadLine();

            while (done == false)
            {
                item = file.ReadLine();

                if (item != null)
                {
                    hero.items.Add(item);
                }
                else
                {
                    done = true;
                }
            }
            file.Close();
            Console.WriteLine("Load Successful {0}.", hero.Identifier);
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
}