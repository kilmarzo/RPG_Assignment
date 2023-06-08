using RPG_Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTests
{
    public class HeroTests
    {
        [Fact]
        public void CreateHero_NameAndLevelAreSet_Correctly()
        {
            // Arrange
            var expectedName = "Test Hero";
            var expectedLevel = 1;

            // Act
            var hero = new Warrior(expectedName);

            // Assert
            Assert.Equal(expectedName, hero.Name);
            Assert.Equal(expectedLevel, hero.Level);
        }

        [Fact]
        public void LevelUp_LevelAndAttributesIncrease_Correctly()
        {
            // Arrange
            var hero = new Warrior("Test Hero");
            var initialLevel = hero.Level;
            var initialStrength = hero.TotalAttributes.Strength;

            // Act
            hero.LevelUp();

            // Assert
            Assert.Equal(initialLevel + 1, hero.Level);
            Assert.Equal(initialStrength + 2, hero.TotalAttributes.Strength); // For warrior, strength increases by 2 each level
        }

        [Fact]
        public void Equip_Weapon_ValidWeapon()
        {
            // Arrange
            var hero = new Warrior("Test Hero");
            var weapon = new Weapon("Axe", 1, WeaponType.Axe, 10);

            // Act
            hero.Equip(weapon);

            // Assert
            Assert.Equal(weapon, hero.Equipment[Slot.Weapon]);
        }

        [Fact]
        public void Equip_Weapon_InvalidLevelThrowsException()
        {
            // Arrange
            var hero = new Warrior("Test Hero");
            var weapon = new Weapon("Axe", 2, WeaponType.Axe, 10);

            // Act & Assert
            Assert.Throws<InvalidEquipmentException>(() => hero.Equip(weapon));
        }

        
    }

}
