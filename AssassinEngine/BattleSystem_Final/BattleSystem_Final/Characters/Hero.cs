using System;
using System.Collections.Generic;
using System.Text;

namespace BattleSystem_Final
{
    public class Hero : Character
    {
        public List<string> items;
        public Hero()
        {
            items = new List<string>();
        }
        public static void Initialize(Hero hero)
        {
            hero.ExpMod = 1;
            hero.LevelCount = 1;
            hero.Strength = 10;
            hero.Constitution = 10;
            hero.Dexterity = 10;
            hero.Intelligence = 8;
            hero.MaxHealth = 20 + ( 2 * (hero.Constitution - 10));
            hero.CurrentHealth = hero.MaxHealth;
            hero.MaxMagic = 10 + ( 2 * (hero.Intelligence - 10));
            hero.CurrentMagic = hero.MaxMagic;
            hero.Defense = hero.Constitution - 10;
            hero.Experience = 0;
            hero.Gold = 0;
            while (hero.Identifier == null || hero.Identifier == "" ||
                hero.Identifier == " ")
            {
                Console.WriteLine("What is your Hero's name?");
                hero.Identifier = Console.ReadLine();
            }
            hero.isAlive = true;
            hero.AttackDamage = hero.Strength;
        }
        public bool CheckItems(string item)
        {
            if (items.Contains(item))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
