using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
          
            foreach (Slot slot in Enum.GetValues(typeof(Slot)))
            {
                Equipment[slot] = null; // Initialize with null values
            }
            
        }

        public void LevelUp()
        {
            Level++;
            LevelAttributes += LevelIncreaseAttributes;
        }

        public void Equip(Item item)
        {
            if (item.RequiredLevel > Level)
            {
                throw new InvalidEquipmentException("You are not high enough level to equip this item.");
            }

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

        public double Damage
        {
            get
            {
                double weaponDamage = (Equipment.ContainsKey(Slot.Weapon) && Equipment[Slot.Weapon] is Weapon weapon) ? weapon.WeaponDamage : 1;
                return weaponDamage * (1 + CalculateDamageAttribute() / 100.0);
            }
        }

        protected abstract int CalculateDamageAttribute();

        public virtual void Display()
        {
            var totalAttributes = TotalAttributes;
            var builder = new StringBuilder();
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