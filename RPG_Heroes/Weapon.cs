using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes
{
    enum WeaponType
    {
        Axe,
        Bow,
        Dagger,
        Hammer,
        Staff,
        Sword,
        Wand
    }
    internal class Weapon : Item
    {
        public WeaponType WeaponType { get; }
        public int WeaponDamage { get; }

        public Weapon(string name, int requiredLevel, WeaponType weaponType, int weaponDamage)
            : base(name, requiredLevel, Slot.Weapon)
        {
            WeaponType = weaponType;
            WeaponDamage = weaponDamage;
        }
    }
}
