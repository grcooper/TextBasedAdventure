using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssassinEngine
{
    public class Character
    {
        public bool defending, increaseAttack;
        protected Random rand;
        protected int AiAttack, AiDefend, AiSpell;
        public int CurrentHealth, MaxHealth, CurrentMagic;
        public int MaxMagic, Strength, Defense, Dexterity;
        public int Constitution, Intelligence;
        public int Experience, Gold, AttackDamage, Level;
        public int ExpMod, LevelCount;
        public string Identifier;
        public bool isAlive;
        protected int spellOne, spellTwo, spellThree;
        public bool fled;
        public int DustBunnyAlive, MoldAlive, VacuumPickup;

        public Character()
        {
            spellOne = 0;
            spellTwo = 0;
            spellThree = 0;
            defending = false;
            increaseAttack = false;
            fled = false;
        }

        public virtual string AI()
        {
            string choice = "";
            return choice;
        }

        public virtual string SpellAI()
        {
            string choice = "";
            return choice;
        }
    }

}
