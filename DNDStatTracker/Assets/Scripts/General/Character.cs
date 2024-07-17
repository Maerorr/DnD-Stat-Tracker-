using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string characterName;
    public int level;
    public Class characterClass;

    public int experience;
    public int armorClass;
    public int initiativeBonus;
    public int speed;

    public int maxHP;
    public int currentHP;
    public int temporaryHP;

    public Dice hitDiceTotal;
    public Dice hitDiceLeft;
    public DeathSaves deathSaves;
    public bool inspiration;

    public int proficiencyBonus;
    public Stats stats;
    public Skills skills;

    public string languageProficiencies;
    public string weaponsProficiencies;
    public string armorProficiencies;
    public string toolsProficiencies;

    public Money money;

    public static Character Default()
    {
        return new Character
        {
            characterName = "Default Name",
            level = 10,
            characterClass = Class.Barbarian,
            experience = 123456,
            armorClass = 15,
            initiativeBonus = 5,
            speed = 30,
            maxHP = 50,
            currentHP = 45,
            temporaryHP = 0,
            hitDiceTotal = new Dice(12, 10),
            hitDiceLeft = new Dice(12, 9),
            deathSaves = new DeathSaves(),
            inspiration = false,
            proficiencyBonus = Utils.ProficiencyBonus(10),
            stats = Stats.Default(),
            skills = Skills.Default(),
            languageProficiencies = "Common, Sylvan, Gnommish.",
            weaponsProficiencies = "Simple and Martial weapons.",
            armorProficiencies = "Light and Medium armor.",
            toolsProficiencies = "Thieves' tools",
            money = new Money(10, 10, 10, 10, 10),
        };
    }

    public void Init()
    {
        proficiencyBonus = Utils.ProficiencyBonus(level);
        skills.proficiencyBonus = proficiencyBonus;
        skills.character = this;
        stats.proficiencyBonus = proficiencyBonus;
    }

    public int GetTotalArmorClass()
    {
        return armorClass + stats.stats["Dexterity"].Mod;
    }

    public int GetTotalInitiative()
    {
        return initiativeBonus + stats.stats["Dexterity"].Mod;
    }
}
