# RPG_Assignment

# RPG Heroes

A lightweight RPG simulation created in C#. Battle foes and become the hero of the realm!

## Table of Contents

- [Description](#description)
- [Features](#features)
- [Setup](#setup)
- [Usage](#usage)
- [Unit Tests](#unit-tests)
- [Contribute](#contribute)

## Description

RPG Heroes is a basic role-playing game (RPG) simulation where you can create heroes of various classes, equip them with weapons and armor, and calculate their attack power.

The core of this game revolves around a Hero class which can be a Warrior, Mage, Ranger, or Rogue. Each Hero has a Level, Name, and distinct attributes for Strength, Dexterity, and Intelligence.

Heroes can equip various Weapons and Armor, which impact their overall combat stats.

## Features

- 4 Hero classes each with unique strengths:
    - Warrior: Strength-focused melee class
    - Mage: Intelligence-focused spellcasting class
    - Ranger: Dexterity-focused ranged class
    - Rogue: Dexterity-focused stealthy class
- A variety of Weapons and Armor to equip
- Calculation of a Hero's damage output based on their equipment and attributes

## Setup

To get started, clone the repository to your local machine:

bash
git clone https://github.com/kilmarzo/RPG_Assignment.git

Then, compile and run the application using an IDE of your choice.

# Usage
Instantiate a Hero of your chosen class, equip them with Weapons and Armor, and then calculate their damage:

Warrior warrior = new Warrior("Aragorn");
Weapon sword = new Weapon("Anduril", 1, WeaponType.Sword, 5);
Armor plate = new Armor("Plate Armor", 1, ArmorType.Plate, new HeroAttribute(2, 0, 0));

warrior.Equip(sword);
warrior.Equip(plate);

double damage = warrior.Damage;

# Unit Tests
Unit tests are provided for the Hero classes. They ensure that damage calculation and equipment handling is functioning as expected.

You can run the unit tests by opening the solution in an IDE that supports .NET Core testing (like Visual Studio or Visual Studio Code), and running the tests.
