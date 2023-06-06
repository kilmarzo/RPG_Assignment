using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes
{
    internal class HeroAttribute
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

        public HeroAttribute(int strength, int dexterity, int intelligence)
        {
            Strength = strength; // Sets the Strength property
            Dexterity = dexterity; // Sets the Dexterity property
            Intelligence = intelligence; // Sets the Intelligence property
        }

        // Overload for the "+" operator for HeroAttribute objects
        public static HeroAttribute operator +(HeroAttribute attribute1, HeroAttribute attribute2)
        {
            int combinedStrength = attribute1.Strength + attribute2.Strength;
            int combinedDexterity = attribute1.Dexterity + attribute2.Dexterity;
            int combinedIntelligence = attribute1.Intelligence + attribute2.Intelligence;

            return new HeroAttribute(combinedStrength, combinedDexterity, combinedIntelligence);
        }

        public void Display()
        {
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Dexterity: {Dexterity}");
            Console.WriteLine($"Intelligence: {Intelligence}");
        }
    }
}
