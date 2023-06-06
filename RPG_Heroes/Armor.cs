using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes
{
    enum ArmorType
    {
        Cloth,
        Leather,
        Mail,
        Plate
    }
    internal class Armor : Item
    {
        public ArmorType ArmorType { get; }
        public HeroAttribute ArmorAttribute { get; }

        public Armor(string name, int requiredLevel, ArmorType armorType, HeroAttribute armorAttribute)
            // Calls the base constructor (Item) and passes name, requiredLevel, and the slot based on armorType.
            : base(name, requiredLevel, GetArmorSlot(armorType))
        {
            ArmorType = armorType;
            ArmorAttribute = armorAttribute;
        }

        private static Slot GetArmorSlot(ArmorType armorType)
        {
            // Switch statement that checks the type of the ArmorType.
            switch (armorType)
            {
                // If the armor type is Cloth, Leather, Mail, or Plate, it goes to the Body slot.
                case ArmorType.Cloth:
                    return Slot.Body;
                case ArmorType.Leather:
                    return Slot.Body;
                case ArmorType.Mail:
                    return Slot.Body;
                case ArmorType.Plate:
                    return Slot.Body;
                default:
                    throw new ArgumentException("Invalid armor type.");
            }
        }
    }
}
