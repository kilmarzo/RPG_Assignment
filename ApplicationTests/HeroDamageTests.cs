using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Heroes;

namespace ApplicationTests
{
    public class HeroDamageTests
    {
        private Hero _hero;
        private Weapon _weapon;
        private Armor _armor;

        public HeroDamageTests()
        {
            _hero = new Warrior("Aragorn");
            _weapon = new Weapon("Common Axe", 1, WeaponType.Axe, 2);
            _armor = new Armor("Common Plate Chest", 1, ArmorType.Plate, new HeroAttribute(1, 0, 0));
        }

        [Fact]
        public void DamageCalculation_NoWeaponEquipped()
        {
            // Base damage should be 1
            // Damage increase should be 5% of 1 (0.05), since default strength is 5
            var expectedDamage = 1 * (1 + (5 / 100.0));
            Assert.Equal(expectedDamage, _hero.Damage);
        }

        [Fact]
        public void DamageCalculation_WithWeaponEquipped()
        {
            _hero.Equip(_weapon);
            // Base damage should be weapon damage which is 2
            // Damage increase should be 5% of 2 (0.1), since default strength is 5
            var expectedDamage = 2 * (1 + (5 / 100.0));
            Assert.Equal(expectedDamage, _hero.Damage);
        }

        [Fact]
        public void DamageCalculation_WithWeaponAndArmorEquipped()
        {
            _hero.Equip(_weapon);
            _hero.Equip(_armor);
            // Base damage should be weapon damage which is 2
            // Damage increase should be 6% of 2 (0.12), since strength is now 6 (5 base + 1 armor)
            var expectedDamage = 2 * (1 + (6 / 100.0));
            Assert.Equal(expectedDamage, _hero.Damage);
        }
    }
}
