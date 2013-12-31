using System;
using System.Collections.Generic;
using System.Text;

namespace BattleSystem_Final
{
    class Mage : Character
    {
        public Mage()
        {
            base.AiAttack = 55;
            base.AiDefend = 65;
            base.AiSpell = 95;

            base.spellOne = 35;
            base.spellTwo = 75;


            base.CurrentHealth = 18;
            base.MaxHealth = 18;
            base.CurrentMagic = 17;
            base.MaxMagic = 17;
            base.Strength = 5;
            base.Defense = 3;
            base.Dexterity = 6;
            base.Experience = 20;
            base.Gold = 15;
            base.Identifier = "The Mage";
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

        public override string SpellAI()
        {
            if (base.CurrentHealth < (base.CurrentHealth / 2))
            {
                spellOne /= 2;
                spellTwo /= 2;
            }
            string choice;
            int ainumberchoice;
            rand = new Random();
            ainumberchoice = rand.Next(1, 100);
            if (ainumberchoice < base.spellOne)
            {
                choice = "F";
            }
            else if (ainumberchoice <= base.spellTwo && ainumberchoice >= base.spellOne)
            {
                choice = "I";
            }
            else
            {
                choice = "H";
            }
            return choice;
        }
    }

}
