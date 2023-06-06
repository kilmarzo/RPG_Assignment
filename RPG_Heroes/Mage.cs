using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes
{
    internal class Mage : Hero
    {
        public Mage(string name) : base(name, new HeroAttribute(1, 2, 5), new HeroAttribute(1, 1, 2)) { }

        protected override int CalculateDamageAttribute()
        {
            return TotalAttributes.Intelligence;
        }
    }
}
