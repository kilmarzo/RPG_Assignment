using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes
{
    internal class Warrior : Hero
    {
        public Warrior(string name) : base(name, new HeroAttribute(5, 2, 1), new HeroAttribute(2, 1, 1)) { }

        protected override int CalculateDamageAttribute()
        {
            return TotalAttributes.Strength;
        }
    }
}
