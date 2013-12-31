using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssassinEngine
{
    class Spell
    {
        public int power;//This is for the base potency of the spell
        public int magicCost;//this is how much HP it costs to cast the spell
        public bool multipleHits, singleTarget, isOnSelf;//These are to determine how to use the spell
        public bool fire, ice, lightning;//These would be used if you want elemental defense and weakness
        public string identifier;

        public Spell()
        {
            multipleHits = false;
            singleTarget = false;
            isOnSelf = false;
            fire = false;
            ice = false;
            lightning = false;
        }

        public virtual int SpellCast(Character caster)
        {
            return power;
        }
    }

}
