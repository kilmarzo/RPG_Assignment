using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ApplicationTests")]


namespace RPG_Heroes
{
    enum Slot
    {
        Weapon,
        Head,
        Body,
        Legs
    }
    internal abstract class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public HeroAttribute StartingAttributes { get; }
        public HeroAttribute LevelIncreaseAttributes { get; }
        public HeroAttribute LevelAttributes { get; private set; }
        public Dictionary<Slot, Item> Equipment { get; } = new Dictionary<Slot, Item>();

        public Hero(string name, HeroAttribute startingAttributes, HeroAttribute levelIncreaseAttributes)
        {
            Name = name;
            Level = 1;
            StartingAttributes = startingAttributes;
            LevelIncreaseAttributes = levelIncreaseAttributes;
            LevelAttributes = startingAttributes;
            InitializeEquipment();
        }

        private void InitializeEquipment()
        {
            // Enum.GetValues returns array of values of constants in the Slot enumeration.
            // Use a loop to iterate over each of these values.
            foreach (Slot slot in Enum.GetValues(typeof(Slot)))
            {
                // For each slot in the hero's equipment (head, body, legs, weapon), we initialize its value to null.
                // This signifies that the hero does not have any equipment in that slot yet.
                Equipment[slot] = null;
            }
        }

        // Handles the logic for leveling up the hero.
        public void LevelUp()
        {
            Level++; // Increase the hero's level by one.

            // Increase the hero's attributes (strength, dexterity, intelligence) by their respective increases upon leveling up.
            LevelAttributes += LevelIncreaseAttributes;
        }

        // Handles the logic for equipping an item to the hero.
        public void Equip(Item item)
        {
            // Check if the hero's level is high enough to equip the item.
            if (item.RequiredLevel > Level)
            {
                throw new InvalidEquipmentException("You are not high enough level to equip this item.");
            }
            
            // If the item is a weapon, check if the hero can equip it
            if (item.Slot == Slot.Weapon)
            {
                if (CanEquipWeapon(item as Weapon))
                {
                    Equipment[Slot.Weapon] = item;
                }
                else
                {
                    throw new InvalidEquipmentException("Invalid weapon type for your class.");
                }
            }
            // If the item is not a weapon (i.e. it's armor) check if the hero can equip it
            else
            {
                if (CanEquipArmor(item as Armor))
                {
                    Equipment[item.Slot] = item;
                }
                else
                {
                    throw new InvalidEquipmentException("Invalid armor type for your class.");
                }
            }
        }

        private bool CanEquipWeapon(Weapon weapon)
        {
            // Default implementation, can be overridden in child classes
            return true;
        }

        private bool CanEquipArmor(Armor armor)
        {
            // Default implementation, can be overridden in child classes
            return true;
        }

        // Property to get the total attributes of a hero.
        // This includes both level attributes and equipment attributes.
        public HeroAttribute TotalAttributes
        {
            get
            {
                HeroAttribute total = LevelAttributes;

                foreach (var item in Equipment.Values)
                {
                    if (item is Armor armor)
                    {
                        total += armor.ArmorAttribute;
                    }
                }

                return total;
            }
        }

        // Property to calculate and get the damage that a hero can deal.
        public double Damage
        {
            get
            {
                // Calculate the weapon damage. If a weapon is equipped, use its damage.
                // If no weapon is equipped, default the weapon damage to 1.
                double weaponDamage = (Equipment.ContainsKey(Slot.Weapon) && Equipment[Slot.Weapon] is Weapon weapon) ? weapon.WeaponDamage : 1;
                // Calculate the total damage by increasing the weapon damage by 1% for each point in the hero's damaging attribute.
                // CalculateDamageAttribute method determines which attribute increases the hero's damage based on their class.
                return weaponDamage * (1 + CalculateDamageAttribute() / 100.0);
            }
        }

        // Abstract method to calculate the attribute (strength, dexterity, or intelligence) 
        // that contributes to the hero's damage based on their class. 
        // This method will be implemented in each specific hero class (Warrior, Mage, etc).
        protected abstract int CalculateDamageAttribute();

        // This method is used to display the details of the Hero instance.
        public virtual void Display()
        {
            // Get total attributes of the hero.
            var totalAttributes = TotalAttributes;
            // Initialize a StringBuilder to create the output string.
            var builder = new StringBuilder();
            // Append hero details to the builder.
            builder.AppendLine($"Hero Details:");
            builder.AppendLine($"Name: {Name}");
            builder.AppendLine($"Class: {GetType().Name}");
            builder.AppendLine($"Level: {Level}");
            builder.AppendLine($"Total Strength: {totalAttributes.Strength}");
            builder.AppendLine($"Total Dexterity: {totalAttributes.Dexterity}");
            builder.AppendLine($"Total Intelligence: {totalAttributes.Intelligence}");
            builder.AppendLine($"Damage: {Damage}");
            builder.AppendLine("Equipment:");
            foreach (var kvp in Equipment)
            {
                // Append the slot and the name of the item equipped in that slot (or "Empty" if no item is equipped).
                builder.AppendLine($"Slot: {kvp.Key} - {(kvp.Value != null ? kvp.Value.Name : "Empty")}");
            }

            Console.WriteLine(builder.ToString());
        }
    }

    class InvalidEquipmentException : Exception
    {
        public InvalidEquipmentException(string message) : base(message)
        {
        }
    }
}