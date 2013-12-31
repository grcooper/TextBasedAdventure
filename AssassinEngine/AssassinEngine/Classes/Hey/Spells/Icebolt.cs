using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssassinEngine
{
    class Icebolt : Spell
    {
        public Icebolt()
        {
            base.identifier = "Icebolt";
            base.power = 12;
            base.singleTarget = true;
            base.magicCost = 2;
        }
        public override int SpellCast(Character Caster)
        {
            Console.WriteLine("{0} casts Icebolt,", Caster.Identifier);
            Caster.CurrentMagic -= magicCost;
            if (Caster.CurrentMagic < 0)
            {
                Caster.CurrentMagic += magicCost;
                Console.WriteLine("however {0} doesn't have enough magic points", Caster.Identifier);
                power = 0;
            }
            else if (Caster.CurrentMagic >= 0)
            {
                Console.WriteLine("and hits for {0}hp of ice damage", power);
            }
            return power;

        }
    }

}
