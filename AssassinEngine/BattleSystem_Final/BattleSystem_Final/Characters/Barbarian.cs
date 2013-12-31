using System;
using System.Collections.Generic;
using System.Text;

namespace BattleSystem_Final
{
    class Barbarian : Character
    {
        public Barbarian()
        {
            Random rand = new Random();

            base.AiAttack = rand.Next(1,100);
            base.AiDefend = 100;
            base.AiSpell = 0;

            base.CurrentHealth = 25;
            base.MaxHealth = 25;
            base.CurrentMagic = 0;
            base.MaxMagic = 0;
            base.Strength = 12;
            base.Constitution = 5;
            base.Dexterity = 4;
            base.Experience = 25;
            base.Gold = 20;
            base.Identifier = "The Barbarian";
            base.isAlive = true;
            base.AttackDamage = Strength;
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
