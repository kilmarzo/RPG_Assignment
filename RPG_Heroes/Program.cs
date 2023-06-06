using RPG_Heroes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a Mage hero
            Hero mage = new Mage("Gandalf");

            // Level up the Mage
            mage.LevelUp();
            mage.LevelUp();

            // Create a weapon
            Weapon staff = new Weapon("Power Staff", 2, WeaponType.Staff, 10);

            // Create armor
            Armor clothArmor = new Armor("Cloth Robe", 2, ArmorType.Cloth, new HeroAttribute(1, 2, 3));

            // Equip the weapon and armor
            mage.Equip(staff);
            mage.Equip(clothArmor);

            // Display the details of the Mage
            mage.Display();

            // Create a Ranger hero
            Hero ranger = new Ranger("Legolas");

            // Level up the Ranger
            ranger.LevelUp();
            ranger.LevelUp();

            // Create a weapon
            Weapon bow = new Weapon("Elven Bow", 2, WeaponType.Bow, 8);

            // Create armor
            Armor leatherArmor = new Armor("Leather Armor", 2, ArmorType.Leather, new HeroAttribute(2, 3, 1));

            // Equip the weapon and armor
            ranger.Equip(bow);
            ranger.Equip(leatherArmor);

            // Display the details of the Ranger
            ranger.Display();

            // Other heroes can be created and displayed in the same way...

        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        Console.ReadLine();
    }
}