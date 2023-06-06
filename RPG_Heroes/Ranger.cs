using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes
{
    internal class Ranger : Hero
    {
        public Ranger(string name) : base(name, new HeroAttribute(2, 5, 1), new HeroAttribute(1, 2, 1)) { }

        protected override int CalculateDamageAttribute()
        {
            return TotalAttributes.Dexterity;
        }
    }
}
