using System;
using System.Collections.Generic;
using System.Text;

namespace AssassinEngine
{
    class Dustbunny : Character
    {
        public Dustbunny()
        {
            Random rand = new Random();

            base.AiAttack = rand.Next(75,100);
            base.AiDefend = 100;
            base.AiSpell = 0;

            base.LevelCount = rand.Next(1,2);
            base.Strength = rand.Next(4,6) + (2 * (LevelCount - 1));
            base.Constitution = rand.Next(10, 15) + (2 * (LevelCount - 1));
            base.Dexterity = rand.Next(1, 2) + (2 * (LevelCount - 1));
            base.Intelligence = 0;
            base.MaxHealth = 20 + (2 * (base.Constitution - 10));
            base.CurrentHealth = base.MaxHealth;
            base.MaxMagic = Math.Max((10 + (2 * (base.Intelligence - 10))), 0);
            base.CurrentMagic = base.MaxMagic;
            base.Defense = base.Constitution - 10;
            base.AttackDamage = Strength;
            base.Experience = 75;
            base.Gold = 0;
            base.Identifier = "Gross Evil Dustbunnies";
            base.isAlive = true;
        }

        public override string AI()
        {
            string choice;
            int ainumberchoice;
            rand = new Random();
            ainumberchoice = rand.Next(1, 100);
            if (ainumberchoice < base.AiAttack)
            {
                choice = "A";
            }
            else if (ainumberchoice <= base.AiDefend && ainumberchoice >= base.AiAttack)
            {
                choice = "D";
            }
            else if (ainumberchoice < base.AiSpell && ainumberchoice > base.AiDefend)
            {
                choice = "S";
            }
            else
            {
                choice = "F";
            }
            return choice;
        }
    }

}
