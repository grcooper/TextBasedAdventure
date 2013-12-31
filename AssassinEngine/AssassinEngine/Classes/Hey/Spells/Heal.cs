using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssassinEngine
{
    class Heal : Spell
    {
        public Heal()
        {
            base.identifier = "Heal";
            base.isOnSelf = true;
            base.power = 30;
            base.magicCost = 3;
        }

        public override int SpellCast(Character Caster)
        {
            Console.WriteLine("{0} casts heal,", Caster.Identifier);
            Caster.CurrentMagic -= magicCost;
            if (Caster.CurrentMagic < 0)
            {
                Caster.CurrentMagic += magicCost;
                Console.WriteLine("however {0} doesn't have enough magic points", Caster.Identifier);
                power = 0;
            }
            else if (Caster.CurrentMagic >= 0)
            {
                Console.WriteLine("and heals {0}hp", power);
            }
            return power;

        }
    }

}
