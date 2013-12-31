using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssassinEngine
{
    class Fireball : Spell
    {
        public Fireball()
        {
            base.identifier = "Fireball";
            base.multipleHits = true;
            base.power = 10;
            base.magicCost = 5;
        }
        public override int SpellCast(Character Caster)
        {
            Console.WriteLine("{0} casts fireball,", Caster.Identifier);
            Caster.CurrentMagic -= magicCost;
            if (Caster.CurrentMagic < 0)
            {
                Caster.CurrentMagic += magicCost;
                Console.WriteLine("however {0} doesn't have enough magic points", Caster.Identifier);
                power = 0;
            }
            else if (Caster.CurrentMagic >= 0)
            {
                Console.WriteLine("and hits for {0}hp of fire damage", power);
            }
            return power;

        }
    }

}
